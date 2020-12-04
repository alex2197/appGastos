using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSPM
{
    [DynamoDBTable("Gastos")]
    public class Gastos
    {
        [DynamoDBHashKey]
        public int id { get; set; }
        public string tipo { get; set; }
        public int monto { get; set; }
        public string fecha { get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string psw { get; set; }
        public async void Save()
        {
            await ConnectionManager.Context.SaveAsync<Gastos>(this);
        }

        public static async Task<List<Gastos>> LoadAll()
        {
            List<Gastos> gastos = new List<Gastos>();
            List<ScanCondition> scanFilter = new List<ScanCondition>();
            AsyncSearch<Gastos> search = ConnectionManager.Context.ScanAsync<Gastos>(scanFilter);

            do
            {
                Task<List<Gastos>> tarea = search.GetNextSetAsync();
                tarea.Wait();
                List<Gastos> results = tarea.Result;

                foreach (Gastos item in results)
                {
                    gastos.Add(item);
                }
            } while (!search.IsDone);
            return gastos;
        }

        public async void Delete()
        {
            await ConnectionManager.Context.DeleteAsync<Gastos>(this);
        }
    }
}
