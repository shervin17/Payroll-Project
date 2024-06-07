using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Dapper;

namespace PayrollV3
{
    public partial class PayrollCalculatorfrm : Form
    {
        private Employee employee1;
        private PayrollPeriod selected;
        EmployeeCalendarDatesRepo calendarDatesRepo = EmployeeCalendarDatesRepo.Instance();
        List<EmployeeCalendarDates> payable_Dates;
        DailyTimeRecordRepository dailyTimeRecordRepository = DailyTimeRecordRepository.Instance();
        List<DailyTimeRecord> daily_time_records;
        Payroll payrollObj;
        EmployeePayrollDetails payrollDetails;
        Leaves leaves;
        private AttendanceSummary attendanceSummary;
        private Leaves for_update_leaves;
        private int allowed_leaves;
        private int no_leaves_to_be_used;
        private decimal grosspay;
        private decimal semi_monthly;
        private decimal adjustments;
        public PayrollCalculatorfrm(Employee employee)
        {
            InitializeComponent();
            employee1 = employee;
        }

        private void PayrollCalculatorfrm_Load(object sender, EventArgs e)
        {
            List<PayrollPeriod> periods = PayrollPeriodRepo.Instance().GetPayrollPeriods();

            comboBox1_payroll_period.DataSource = periods;

            comboBox1_payroll_period.SelectedIndexChanged += comboBox1_payroll_period_SelectedIndexChanged;

            
        }


        private void comboBox1_payroll_period_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            selected = comboBox1_payroll_period.SelectedItem as PayrollPeriod;
            
            
            try 
            {
                payable_Dates = calendarDatesRepo.GetPayableDates(selected.Payroll_period_id);
                daily_time_records = dailyTimeRecordRepository.findDTRbyEmployeeID(employee1.Id, selected);
                payrollDetails = EmployeePayrollDetailsRepo.Instance().getByID(employee1.Payroll_details_id);
                leaves = LeavesRepo.Instance().FindByID(employee1.Leaves_id);
                dataGridView1.DataSource = daily_time_records;
            }
            catch (Exception ex)
            {
                MessageBox.Show("an error has occured "+ex.Message);
            }

            payrollObj = new Payroll(daily_time_records, payable_Dates,payrollDetails);
            attendanceSummary = payrollObj.GetAttendanceSummary();
            populateFields();
            allowed_leaves = attendanceSummary.NumberOfAbsents == 0? 5: attendanceSummary.NumberOfAbsents + 5;
            semi_monthly = Math.Round(payrollDetails.Salary / 2, 2);
            
        }

        public void populateFields() 
        {
         days_of_work_Field.Text= payable_Dates.Count.ToString();
         Holiday_Credited_field.Text= attendanceSummary.HolidayCredited.ToString();
         Special_Hol_field.Text=attendanceSummary.SpecialHolidayCredited.ToString();
         PayableOTmin_Field.Text = " ";
         OvertimePay_field.Text = " ";
         Semi_Monthly_Salary_field.Text= semi_monthly.ToString();
         days_absent_field.Text= attendanceSummary.NumberOfAbsents.ToString();
         TotalMinsLate_field.Text=attendanceSummary.TotalMinsLate.ToString();
         DeductibleLateMins_Field.Text= attendanceSummary.DeductibleMinsLate.ToString();
         Deduction_due_toLate_field.Text= attendanceSummary.DeductionDueToLate.ToString();
         TotalUnderTimeMins_Field.Text=attendanceSummary.TotalUndertimeMins.ToString();
         Deductible_under_time_mins_field.Text = attendanceSummary.DeductibleUndertimeMins.ToString();
         Deduction_due_to_underTimeField.Text = attendanceSummary.DeductionDueToUndertime.ToString();

            VL_numeric.Maximum = leaves.Remaining_VL;
            SL_numeric.Maximum = leaves.Remaining_SL;
            Emergency_Leave_numeric.Maximum = leaves.Emergency_leave;
            Bereavement_numeric.Maximum = 5;
        }

        public void updateLeavesOnUSe(object sender, EventArgs e) {

            if (payrollDetails == null)
            {
                clearNumericFields();
                return;
            }
            if(no_leaves_to_be_used == allowed_leaves)
            {
                clearNumericFields();
                return;
            }

            no_leaves_to_be_used = (int)(VL_numeric.Value + SL_numeric.Value + Bereavement_numeric.Value + Emergency_Leave_numeric.Value);

            adjustments = no_leaves_to_be_used * payrollDetails.Daily_rate;
            AdjustmentAmountField.Text = (adjustments.ToString());
        }
        public void clearNumericFields() 
        {
            VL_numeric.Value = 0;
            SL_numeric.Value = 0;
            Bereavement_numeric.Value = 0;
            Emergency_Leave_numeric.Value = 0;
            AdjustmentAmountField.Text = " ";
            no_leaves_to_be_used = 0;
        }

        private void button5_Click(object sender, EventArgs e) 
        {
            //apply leaves button

            DialogResult dialogResult = MessageBox.Show("This will consume leaves . Do you wish to proceed?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dialogResult == DialogResult.No) {
                clearNumericFields() ;
                return;
            }

            for_update_leaves = new Leaves
            {
                Leaves_id = leaves.Leaves_id,
                Remaining_SL = leaves.Remaining_SL - SL_numeric.Value,
                Remaining_VL = leaves.Remaining_VL - VL_numeric.Value,
                Emergency_leave = leaves.Emergency_leave - (int)Emergency_Leave_numeric.Value,
                Bereavement_leave_used = leaves.Bereavement_leave_used + (int) Bereavement_numeric.Value,
            };
            MessageBox.Show(for_update_leaves.ToString() );
            updateGrossPay();
        }
        private void updateGrossPay() {

            grosspay = semi_monthly + adjustments -( attendanceSummary.DeductionDueToLate + attendanceSummary.DeductionDueToUndertime);
            MessageBox.Show($" {semi_monthly} + {adjustments} - ({attendanceSummary.DeductionDueToLate} + {attendanceSummary.DeductionDueToUndertime}) = {grosspay}");
            GrossPayField.Text= grosspay.ToString();
        }
    }
}
