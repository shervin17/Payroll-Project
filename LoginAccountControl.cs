using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Dapper;
namespace PayrollV3
{
    public partial class LoginAccountControl : UserControl
    {
        public LoginAccountControl()
        {
            InitializeComponent();
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            
        }

        private int validateLogins()
        {

            int user_id = 0;
            string username = username_field.Text;
            string password = password_field.Text;

            try
            {
                using (SqlConnection connection = DBConnection.getConnection())
                {

                    string query = "select id from employee inner join employee_logins on employee.logins_id = employee_logins.logins_id where username = @username and password = @password ";

                    var result = connection.QueryFirstOrDefault(query, new { @username = username, @password = password });
                    if (result != null)
                    {
                        user_id = result.id;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            return user_id;
        }


    }
}
