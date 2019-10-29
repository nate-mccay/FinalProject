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
            cmd.CommandText = "select * from question as q INNER JOIN answer as a on a.question_id = q.question_id; ";
            using (conn)
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                List<Question> allQuestions = new List<Question>();
                while (reader.Read() == true)
                {
                    var currentQuestion = new Question();
                    currentQuestion.QuestionID = reader.GetInt32("answer_id");
                    currentQuestion.Quest = reader.GetString("question");
                    currentQuestion.Ans = reader.GetString("answer");
                    allQuestions.Add(currentQuestion);
                }
                return allQuestions;
            }
        }
    }
}
