using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interface;
using WebApi.Model;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
namespace WebApi.Implementation
{
    public class VacunaService : IVacunaService
    {
        private readonly string _connectionString;

        public VacunaService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


public async Task InsertarVacuna(Vacuna vacuna)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("insertar_vacuna", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NombreVacuna", vacuna.NombreVacuna);
                    cmd.Parameters.AddWithValue("@Descripcion", vacuna.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", vacuna.Estado);
                    cmd.Parameters.AddWithValue("@FechaAplicacion", vacuna.FechaAplicacion);
                    cmd.Parameters.AddWithValue("@IdAnimal", vacuna.IdAnimal);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task ModificarVacuna(Vacuna vacuna)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("modificar_vacuna", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdVacuna", vacuna.IdVacuna);
                    cmd.Parameters.AddWithValue("@NombreVacuna", vacuna.NombreVacuna);
                    cmd.Parameters.AddWithValue("@Descripcion", vacuna.Descripcion);
                    cmd.Parameters.AddWithValue("@Estado", vacuna.Estado);
                    cmd.Parameters.AddWithValue("@FechaAplicacion", vacuna.FechaAplicacion);
                    cmd.Parameters.AddWithValue("@IdAnimal", vacuna.IdAnimal);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Vacuna> BuscarVacunaPorId(int id)
        {
            Vacuna vacuna = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("buscar_vacuna_id", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdVacuna", id);

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            vacuna = new Vacuna
                            {
                                IdVacuna = reader.GetInt32(0),
                                NombreVacuna = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Estado = reader.GetBoolean(3),
                                FechaAplicacion = reader.GetDateTime(4),
                                IdAnimal = reader.GetInt32(5)
                            };
                        }
                    }
                }
            }

            return vacuna;
        }

        public async Task<List<Vacuna>> ListarVacunas()
        {
            List<Vacuna> vacunas = new List<Vacuna>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("listar_vacunas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            vacunas.Add(new Vacuna
                            {
                                IdVacuna = reader.GetInt32(0),
                                NombreVacuna = reader.GetString(1),
                                Descripcion = reader.GetString(2),
                                Estado = reader.GetBoolean(3),
                                FechaAplicacion = reader.GetDateTime(4),
                                IdAnimal = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }

            return vacunas;
        }

        public async Task EliminarVacuna(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("eliminar_vacuna", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdVacuna", id);

                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

    }
}