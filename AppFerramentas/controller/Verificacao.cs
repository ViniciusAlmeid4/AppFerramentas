using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using AppFerramentas.Models;
using MySqlConnector;
using Xamarin.Forms.Internals;

namespace AppFerramentas.controller
{
    public class Verificacao
    {
        static string conn = @"server=sql.freedb.tech;port=3306;database=freedb_sql.freedb.tech1;user id=freedb_freedb_vini_almeida;password=ys!976NXhE&#cHh;charset=utf8";

        public static List<Verificados> ListarVerificacao()
        {
            List<Verificados> ver = new List<Verificados>();

            string sql = "SELECT * FROM verificacao";//"SELECT v.id_verificacao,fc.nome_funcionario,fr.nome_ferramenta,v.data_verificacao FROM `verificacao` v JOIN `ferramenta` fr ON v.id_ferra = fr.id_ferramenta JOIN `funcionario` fc ON v.id_func = fc.id_funcionario WHERE data_verificacao < CURRENT_TIMESTAMP;";

            using (MySqlConnection con = new MySqlConnection(conn))
            {

                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Verificados verif = new Verificados()
                            {

                                id_verificacao = reader.GetInt32(0),
                                nome_funcionario = reader.GetString(1),
                                nome_ferramenta = reader.GetString(2),
                                data_verificacao = reader.GetString(3),
                                // set time_zone = 'America/Sao_Paulo';
                            };

                            ver.Add(verif);
                        }

                    }

                }

                con.Close();

                return ver;
            }
        }

        public static void Verifica(string id_ferramenta) // passar o i de algm jeito
        {
            var pessoa = Pessoas.ListarFuncionario();
            string sql = "INSERT INTO verificacao(id_func, id_ferra, data_verificacao) VALUES (@id_func, @id_ferra, curDate())";

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id_func", MySqlDbType.Int32).Value = pessoa.Last().id_funcionario;
                    cmd.Parameters.Add("@id_ferra", MySqlDbType.Int32).Value = id_ferramenta;
					//cmd.Parameters.Add("@data_vericacao", DbType.Date).Value = DateTime.Now;
					cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public static void Truncate()
        {
			string sql = "TRUCATE TABLE verificacao";

			using (MySqlConnection con = new MySqlConnection(conn))
			{
				con.Open();

				using (MySqlCommand cmd = new MySqlCommand(sql, con))
				{
					cmd.CommandType = CommandType.Text;
					cmd.ExecuteNonQuery();
				}

				con.Close();
			}
		}
    }
}
