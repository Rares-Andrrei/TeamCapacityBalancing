﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCapacityBalancing.Models;

namespace TeamCapacityBalancing.Services.Postgres_connection
{
    internal class QueriesForDataBase
    {
        public static List<User> GetAllUsers() 
        { 
            List<User> users = new List<User>();

            try
            {
                using (var connection = new NpgsqlConnection(DataBaseConnection.GetInstance().GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand("SELECT * FROM public.\"cwd_user\"", connection))
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            string username = reader.GetString(reader.GetOrdinal("user_name"));
                            string displayName = reader.GetString(reader.GetOrdinal("display_name"));
                            int id = reader.GetInt32(reader.GetOrdinal("id"));

                            users.Add(new User(username, displayName, id));
                        }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return users;
        }

        public static List<IssueData> GetStoriesByEpic(int epicId)
        {
            List<IssueData> stories = new List<IssueData>();

            try
            {
                using (var connection = new NpgsqlConnection(DataBaseConnection.GetInstance().GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand($"SELECT * FROM jiraissue AS ji JOIN issuelink AS il ON ji.id = il.destination WHERE il.linktype = 10201 and il.source = {epicId}"
                        , connection))

                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(reader.GetOrdinal("id"));
                            string name = reader.GetString(reader.GetOrdinal("summary"));
                            
                        }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return stories;
        }
    }
}
