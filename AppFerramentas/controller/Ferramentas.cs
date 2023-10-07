using AppFerramentas.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace AppFerramentas.controller
{
    public class Ferramentas
    {
        static string conn = @"server=sql.freedb.tech;port=3306;database=freedb_sql.freedb.tech1;user id=freedb_freedb_vini_almeida;password=ys!976NXhE&#cHh;charset=utf8";

        public static List<Ferramenta> ListarFerramentas()
        {
            List<Ferramenta> fer = new List<Ferramenta>();

            string sql = "SELECT * FROM ferramenta";

            using (MySqlConnection con = new MySqlConnection(conn))
            {

                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            Ferramenta ferra = new Ferramenta()
                            {

                                id_ferramenta = reader.GetInt32(0),
                                tipo = reader.GetString(1),
                                nome_ferramenta = reader.GetString(2),
                                codigo = reader.GetString(3),

                            };

                            fer.Add(ferra);
                        }

                    }

                }

                con.Close();

                return fer;
            }
        }

        public static void InserirFerramenta(string tipo, string nome_ferramenta, string codigo)
        {
            string sql = "INSERT INTO ferramenta(tipo,nome_ferramenta,codigo,id_funcionario) VALUES (@tipo,@nome_ferramenta, @codigo, @id_funcionario)";

            List<Pessoa> pessoa = new List<Pessoa>();

            pessoa = Pessoas.ListarFuncionario();

            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = tipo;
                    cmd.Parameters.Add("@nome_ferramenta", MySqlDbType.VarChar).Value = nome_ferramenta;
                    cmd.Parameters.Add("@codigo", MySqlDbType.VarChar).Value = codigo;
                    cmd.Parameters.Add("@id_funcionario", MySqlDbType.Int32).Value = pessoa[0].id_funcionario;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }

        public static void AtualizarFerramenta(Ferramenta ferramenta)
        {
            string sql = "UPDATE ferramenta SET tipo=@tipo, nome_ferramenta=@nome_ferramenta WHERE id_ferramenta=@id_ferramenta";

            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@tipo", MySqlDbType.VarChar).Value = ferramenta.tipo;
                        cmd.Parameters.Add("@nome_ferramenta", MySqlDbType.VarChar).Value = ferramenta.nome_ferramenta;
                        cmd.Parameters.Add("@id_ferramenta", MySqlDbType.Int32).Value = ferramenta.id_ferramenta;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ExcluirFerramenta(Ferramenta ferramenta)
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
                throw new Exception(ex.Message);
            }
        }
        
    }
}