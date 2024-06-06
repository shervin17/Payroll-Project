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
                dataGridView1.DataSource = daily_time_records;
            }
            catch (Exception ex)
            {
                MessageBox.Show("an error has occured "+ex.Message);
            }
            
            payrollObj = new Payroll(daily_time_records, payable_Dates,payrollDetails);
            MessageBox.Show(payrollDetails.ToString());
            AttendanceSummary attendanceSummary = payrollObj.GetAttendanceSummary();
            MessageBox.Show(attendanceSummary.ToString());
        }
    }
}
