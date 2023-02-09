using MVCCrudDoctores.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVCCrudDoctores.Repositories
{
    public class RepositoryDoctores
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDoctores()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;User ID=sa; Password=";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public List<Doctor> GetDoctors()
        {
            string sql = "SELECT * FROM DOCTOR";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> Doctors = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.DOCTOR_NO = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.HOSPITAL_COD = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.APELLIDO = this.reader["APELLIDO"].ToString();
                doctor.ESPECIALIDAD = this.reader["ESPECIALIDAD"].ToString();
                doctor.SALARIO = int.Parse(this.reader["SALARIO"].ToString());
                Doctors.Add(doctor);
            }
            this.reader.Close();
            this.cn.Close();
            return Doctors;
        }

        public Doctor FindDoctor(int id)
        {
            string sql = "SELECT * FROM DOCTOR WHERE DOCTOR_NO=@DOCTORID";
            SqlParameter pamid = new SqlParameter("@DOCTORID", id);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.reader.Read();
            Doctor doctor = new Doctor();
            doctor.DOCTOR_NO = int.Parse(this.reader["DOCTOR_NO"].ToString());
            doctor.HOSPITAL_COD = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            doctor.APELLIDO = this.reader["APELLIDO"].ToString();
            doctor.ESPECIALIDAD = this.reader["ESPECIALIDAD"].ToString();
            doctor.SALARIO = int.Parse(this.reader["SALARIO"].ToString());
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return doctor;
        }

        public void InsertDoctor(int id, int hospitalcod, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES (@DOCTOR_NO, @HOSPITAL_COD, @APELLIDO, @ESPECIALIDAD, @SALARIO)";
            SqlParameter pamid = new SqlParameter("@DOCTOR_NO", id);
            SqlParameter pamhospital = new SqlParameter("@HOSPITAL_COD", hospitalcod);
            SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamhospital);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateDoctor(int id, int hospitalcod, string apellido, string especialidad, int salario)
        {
            string sql = "UPDATE DOCTOR SET APELLIDO=@APELLIDO, ESPECIALIDAD=@ESPECIALIDAD, SALARIO=@SALARIO, HOSPITAL_COD=@HOSPITAL_COD WHERE DOCTOR_NO=@ID";
            SqlParameter pamid = new SqlParameter("@ID", id);
            SqlParameter pamhospital = new SqlParameter("@HOSPITAL_COD", hospitalcod);
            SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamhospital);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void DeleteDoctor(int id)
        {
            string sql = "DELETE FROM DOCTOR WHERE DOCTOR_NO=@ID";
            SqlParameter pamid = new SqlParameter("@ID", id);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.cn.Close();
            this.com.Parameters.Clear();
        }
    }
}
