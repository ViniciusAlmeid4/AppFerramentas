using AppFerramentas.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppFerramentas.controller
{
    public class Pessoas
    {
        static string conn = @"server=sql.freedb.tech;port=3306;database=freedb_sql.freedb.tech1;user id=freedb_freedb_vini_almeida;password=ys!976NXhE&#cHh;charset=utf8";

        public static List<Pessoa> ListarFuncionario()
        {
            List<Pessoa> pes = new List<Pessoa>();

            string sql = "SELECT * FROM funcionario";

            using (MySqlConnection con = new MySqlConnection(conn))
            {

                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Pessoa pessoa = new Pessoa()
                            {

                                id_funcionario = reader.GetInt32(0),
                                nome_funcionario = reader.GetString(1),
                                setor = reader.GetString(2),
                                gerente = reader.GetString(3),
                                cargo = reader.GetString(4),

                            };

                            pes.Add(pessoa);
                        }

                    }

                }

                con.Close();

                return pes;
            }
        }

        public static void InserirFuncionario(string nome_funcionario, string setor, string gerente, string cargo)
        {
            string sql = "INSERT INTO funcionario(nome_funcionario, setor, gerente, cargo) VALUES (@nome_funcionario, @setor, @gerente, @cargo)";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nome_funcionario", MySqlDbType.VarChar).Value = nome_funcionario;
                    cmd.Parameters.Add("@setor", MySqlDbType.VarChar).Value = setor;
                    cmd.Parameters.Add("@gerente", MySqlDbType.VarChar).Value = gerente;
                    cmd.Parameters.Add("@cargo", MySqlDbType.VarChar).Value = cargo;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }
        public static void ExcluirFuncionario(Ferramenta ferramenta)
        {
            string sql = "DELETE FROM ferramenta WHERE id_ferramenta=@id_ferramenta";

            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@id_ferramenta", MySqlDbType.Int32).Value = ferramenta.id_ferramenta;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}
