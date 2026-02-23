using Dapper;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DapperContext _context;

    public EmployeeRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> GetAllAsync()
    {
        var query = "SELECT * FROM Employees";
        using var connection = _context.CreateConnection();
        return await connection.QueryAsync<Employee>(query);
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        var query = "SELECT * FROM Employees WHERE Id = @Id";
        using var connection = _context.CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<Employee>(query, new { Id = id });
    }

    public async Task<int> CreateAsync(Employee employee)
    {
        var query = @"INSERT INTO Employees (Name, Department, Email, Salary,ProfileImageUrl)
                      VALUES (@Name, @Department, @Email, @Salary,@ProfileImageUrl);
                      SELECT CAST(SCOPE_IDENTITY() as int);";

        using var connection = _context.CreateConnection();
        return await connection.ExecuteScalarAsync<int>(query, employee);
    }

    public async Task<bool> UpdateAsync(Employee employee)
    {
        var query = @"UPDATE Employees 
                      SET Name=@Name, Department=@Department, Email=@Email, Salary=@Salary,ProfileImageUrl = @ProfileImageUrl
                      WHERE Id=@Id";

        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(query, employee);
        return rows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var query = "DELETE FROM Employees WHERE Id=@Id";
        using var connection = _context.CreateConnection();
        var rows = await connection.ExecuteAsync(query, new { Id = id });
        return rows > 0;
    }
}
