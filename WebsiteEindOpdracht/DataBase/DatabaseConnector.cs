﻿using MySql.Data.MySqlClient;
using WebsiteEindOpdracht.Models;
using System.Collections.Generic;

namespace WebsiteEindOpdracht.Database
{
  public static class DatabaseConnector
  {

    public static List<Dictionary<string, object>> GetRows(string query)
    {
      // stel in waar de database gevonden kan worden
      // string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=fastfood;Uid=lgg;Pwd=<jouwwachtwoordhier>;";
      string connectionString = "Server=172.16.160.21;Port=3306;Database=111137;Uid=111137;Pwd=Inf2022sql;";
      //string connectionString = "Server=127.0.0.1; Port=3306;Database=111137;Uid=111137;Pwd=Password1234";

      // maak een lege lijst waar we de namen in gaan opslaan
      List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

      
      // verbinding maken met de database
      using (MySqlConnection conn = new MySqlConnection(connectionString))
      {
        // verbinding openen
        conn.Open();

        // SQL query die we willen uitvoeren
        MySqlCommand cmd = new MySqlCommand(query, conn);

        // resultaat van de query lezen
        using (var reader = cmd.ExecuteReader())
        {
          var tableData = reader.GetSchemaTable();

          // elke keer een regel (of eigenlijk: database rij) lezen
          while (reader.Read())
          {
            var row = new Dictionary<string, object>();

            // haal voor elke kolom de waarde op en voeg deze toe
            for (int i = 0; i < reader.FieldCount; i++)
            {
              row[reader.GetName(i)] = reader.GetValue(i);
            }

            rows.Add(row);
          }
        }
      }

      // return de lijst met namen
      return rows;
    }

     public static void SavePerson(Person person)
     {
         using (MySqlConnection conn = new MySqlConnection(connectionString))
         {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO contact(Naam, Achternaam, Email, Bericht) VALUES(?Naam, ?Achternaam, ?Email, ?Bericht)", conn);

                // Elke parameter moet je handmatig toevoegen aan de query
                cmd.Parameters.Add("?Naam", MySqlDbType.Text).Value = person.FirstName;
                cmd.Parameters.Add("?Achternaam", MySqlDbType.Text).Value = person.LastName;
                cmd.Parameters.Add("?Email", MySqlDbType.Text).Value = person.EmailAdress;
                cmd.Parameters.Add("?Bericht", MySqlDbType.Text).Value = person.Description;
                cmd.ExecuteNonQuery();
         }
     }

    }
}