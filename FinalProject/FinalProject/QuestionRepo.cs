using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using FinalProject.Models;

namespace FinalProject
{
    public class QuestionRepo
    {
        private static string connection = System.IO.File.ReadAllText("connection.txt");
        public List<Question> GetAllQuestions()
        {
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from source;";
            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Question> allQuestions = new List<Question>();
                while (reader.Read() == true)
                {
                    var currentQuestion = new Question();
                    currentQuestion.QuestionID = reader.GetInt32("id");
                    currentQuestion.Quest = reader.GetString("question");
                    currentQuestion.Ans = reader.GetString("answer");
                    allQuestions.Add(currentQuestion);
                }
                return allQuestions;
            }
        }

        public Question GetQuestion(int id)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from source WHERE id = @id;";
            cmd.Parameters.AddWithValue("id", id);

            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                var currentQuestion = new Question();

                while (reader.Read() == true)
                {
                    
                    currentQuestion.QuestionID = reader.GetInt32("id");
                    currentQuestion.Quest = reader.GetString("question");
                    currentQuestion.Ans = reader.GetString("answer");
                    
                }
                return currentQuestion;
            }
        }
        public void InsertFlash(Question flashToInsert)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO source (question, answer) values(@question, @answer)";
            cmd.Parameters.AddWithValue("question", flashToInsert.Quest);
            cmd.Parameters.AddWithValue("answer", flashToInsert.Ans);
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteQuestion(int id)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM source WHERE id = @id;";
            cmd.Parameters.AddWithValue("id", id);
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateQuestion(Question flashToUpdate)
        {
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "Update source SET question = @question,answer = @answer WHERE id = @id;";
            cmd.Parameters.AddWithValue("question",flashToUpdate.Quest);
            cmd.Parameters.AddWithValue("answer", flashToUpdate.Ans);
            cmd.Parameters.AddWithValue("id", flashToUpdate.QuestionID);

            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
