using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class GetCursoQueryNUnitTest
    {
        private GetCursoQuery.GetCursoQueryHandler handlerAllCursos;

        [SetUp]
        public void Setup()
        {
            // 1. Emular a Context que representa la instancia de EF

            // 2. Emular al Mapping Profile

            // 3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandler y pasarle
            // como parámetros los objetos context y mapping
            // GetCursoQueryHandler(context, mapping) => handle

            var fixture = new Fixture();
            var cursoRecords = fixture.CreateMany<Curso>().ToList();

            cursoRecords.Add(fixture.Build<Curso>()
                .With(tr => tr.CursoId, Guid.Empty)
                .Create()
                );

            var options = new DbContextOptionsBuilder<EducationDBContext>()
                .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                .Options;

            var educationDbContextFake = new EducationDBContext(options);
            educationDbContextFake.Cursos.AddRange(cursoRecords);
            educationDbContextFake.SaveChanges();

            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            var mapper = mapConfig.CreateMapper();

            handlerAllCursos = new GetCursoQuery.GetCursoQueryHandler(educationDbContextFake, mapper);
        }

        [Test]
        public async Task GetCursoQueryHandler_ConsultaCursos_ReturnsTrue()
        {
            GetCursoQuery.GetCursoQueryRequest request = new();
            var resultados = await handlerAllCursos.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(resultados);
        }
    }
}
