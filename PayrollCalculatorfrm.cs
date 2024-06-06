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
            payable_Dates = calendarDatesRepo.GetPayableDates(selected.Payroll_period_id);
            try 
            {
                daily_time_records = dailyTimeRecordRepository.findDTRbyEmployeeID(employee1.Id, selected);
                dataGridView1.DataSource = daily_time_records;
            }
            catch (Exception ex)
            {
                MessageBox.Show("an erro has occured "+ex.Message);
            }
        }
    }
}
