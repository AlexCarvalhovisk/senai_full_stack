using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
{
    
}
class Banco
{
    public string mensagem = "Olá banco";

    private List<Pessoa> lista = new List<Pessoa>();
    public void carregarBanco(){

            try{

                    SqlConnectionStringBuilder builder = SqlConnectionStringBuilder(
                    
                    "User ID = sa; Passaword = 1234;" + 
                    "Server = localhost\\SQLEXPRESS;" +
                    "Database = projetoclientes;" +
                    "Trusted_Connection = false;"

                    );

                    using (SqlConnection conexao = SqlConnection(builder.ConnectionString))
                    {
                        String sql = "select from * clientes";

                        using(SqlCommand comando = new SqlCommand(sql, conexao)){

                            conexao.Open();
                            using (SqlDataReader tabela = comando.ExecuteReader()){

                                while (tabela.Read())
                                {
                                    //System.Console.WriteLine(tabela["nome: "])
                                    //Pessoa p1 = new Pessoa () {id = 1, nome = "Ana"};
                                    lista.Add(
                                        new Pessoa(){
                                            //Dados retornados e convertidos do banco para o Back.
                                            id = Convert.ToInt32(tabela["id"]),
                                            nome = tabela["nome"].ToString()

                                        }
                                    );
                                }
                                
                            }

                        }

                    }

            }catch(Exception e){

                System.Console.WriteLine("Erro de banco de dados:" + e.ToString);

            }

    }

    public List<Pessoa> GetLista(){

        return lista;

    }

}