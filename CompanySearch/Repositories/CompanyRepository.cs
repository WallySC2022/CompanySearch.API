using CompanySearch.Models;
using System.Data;
using System.Data.SqlClient;

namespace CompanySearch.Repositories
{
    public class CompanyRepository
    {
        public void ConsultarEmpresa()
        {
            SqlConnection sqlConnection;
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;
            List<Company> companies;
            Company company;

            try
            {
                sqlConnection = new SqlConnection(Configs.DBStringConnection);
                sqlConnection.Open();

                sqlCommand = new SqlCommand("select * from Empresas", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                
                companies = new List<Company>();

                while (sqlDataReader.Read())
                {
                    //var empresaNome = sqlDataReader["nome"];
                    company = new Company();

                    company.Nome = sqlDataReader["Nome"].ToString();
                    company.Uf = sqlDataReader["uf"].ToString();
                    company.Telefone = sqlDataReader["Telefone"].ToString();
                    company.Email = sqlDataReader["email"].ToString();
                    company.Situacao = sqlDataReader["situacao"].ToString();

                    companies.Add(company);
                }

                sqlConnection.Close();              
            }
           
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void CriarEmpresa(Company company)
        {
            SqlConnection sqlConnection;
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;

            try
            {
                sqlConnection = new SqlConnection(Configs.DBStringConnection);
                {
                    string comandoSQL = @"Insert into Empresas(NOME,
                                                               UF,
                                                               TELEFONE,
                                                               EMAIL,
                                                               SITUACAO) 
                                                        Values(@NOME,
                                                               @UF,
                                                               @TELEFONE,
                                                               @EMAIL,
                                                               @SITUACAO)";

                    sqlCommand = new SqlCommand(comandoSQL, sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;

                    sqlCommand.Parameters.AddWithValue("NOME", company.Nome);
                    sqlCommand.Parameters.AddWithValue("@UF", company.Uf);
                    sqlCommand.Parameters.AddWithValue("@TELEFONE", company.Telefone);
                    sqlCommand.Parameters.AddWithValue("@EMAIL", company.Email);
                    sqlCommand.Parameters.AddWithValue("@SITUACAO", company.Situacao);

                    sqlConnection.Open();
                    var lines = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void AtualizarEmpresa(Company company)
        {
            SqlConnection sqlConnection;
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;

            try
            {
                sqlConnection = new SqlConnection(Configs.DBStringConnection);
                {
                    string comandoSQL = "Update Empresas set Nome = @Nome, uf = @uf, telefone = @telefone, email = @email, situacao = @situacao, bairro = @bairro, municipio = @municipio, porte = @porte, status = @status, numero = @numero";
                    sqlCommand = new SqlCommand(comandoSQL, sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;

                    sqlCommand.Parameters.AddWithValue("@Nome", company.Nome);
                    sqlCommand.Parameters.AddWithValue("@uf", company.Uf);
                    sqlCommand.Parameters.AddWithValue("@telefone", company.Telefone);
                    sqlCommand.Parameters.AddWithValue("@email", company.Email);
                    sqlCommand.Parameters.AddWithValue("@situacao", company.Situacao);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public void DeletarEmpresa(Company company)
        {
            SqlConnection sqlConnection;
            SqlCommand sqlCommand;
            SqlDataReader sqlDataReader;

            try
            {
                sqlConnection = new SqlConnection(Configs.DBStringConnection);
                {
                    string comandoSQL = "Delete from Empresas where Nome = @Nome, uf = @uf, telefone = @telefone, email = @email, situacao = @situacao, bairro = @bairro, municipio = @municipio, porte = @porte, status = @status, numero = @numero";
                    sqlCommand = new SqlCommand(comandoSQL, sqlConnection);
                    sqlCommand.CommandType = CommandType.Text;

                    //sqlCommand.Parameters.AddWithValue("@Nome", "Maycon");

                    sqlCommand.Parameters.AddWithValue("@Nome", company.Nome);
                    sqlCommand.Parameters.AddWithValue("@uf", company.Uf);
                    sqlCommand.Parameters.AddWithValue("@telefone", company.Telefone);
                    sqlCommand.Parameters.AddWithValue("@email", company.Email);
                    sqlCommand.Parameters.AddWithValue("@situacao", company.Situacao);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
