using Api.Application.Services;
using Api.Domain.Models;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Api.Application.DTO.Create;
using Api.Application.DTO.Get;
using Api.Domain.Models.Identity;
using Infrastructure.Persistence.EntityConfigs;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence.ServiceImplementations;

public class StudentService : BaseService<Student>,IStudentService
{
    public StudentService(VafeeContext context) : base(context)
    {
        
    }
}