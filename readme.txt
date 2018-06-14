Requirements: VS 2013, PostgreSQL. PgAdmin3 and above allows to view BD and tables.

Description:
This example shows how to work with EntityFramework.
Creates connection to Postgres.
Creates tables 'persons', 'teachers', 'students', 'phones'.
Shows 'many to many' scheme between students and teachers.
Queries use Linq.

Details:
EntityFramework, Npgsql, Npgsql for Entity Framework 6 were added (through Nuget) to the project.
defaultConnectionFactory in App.config was changed from System.Data.Entity.Infrastructure.SqlConnectionFactory
to Npgsql.NpgsqlConnectionFactory.
DbProviderFactories section was added. It contains Npgsql Data Provider.