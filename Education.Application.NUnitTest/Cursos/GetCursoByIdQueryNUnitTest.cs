using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    public class GetCursoByIdQueryNUnitTest
    {
        [TestFixture]
        public class GetCursoQueryNUnitTest
        {
            private GetCursoByIdQuery.GetCursoByIdQueryHandler handlerByIdCurso;
            private Guid cursoIdTest;

            [SetUp]
            public void Setup()
            {
                // 1. Emular a Context que representa la instancia de EF

                // 2. Emular al Mapping Profile

                // 3. Instanciar un objeto de la clase GetCursoQuery.GetCursoQueryHandler y pasarle
                // como parámetros los objetos context y mapping
                // GetCursoQueryHandler(context, mapping) => handle

                cursoIdTest = Guid.NewGuid();
                var fixture = new Fixture();
                var cursoRecords = fixture.CreateMany<Curso>().ToList();

                cursoRecords.Add(fixture.Build<Curso>()
                    .With(tr => tr.CursoId, cursoIdTest)
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

                handlerByIdCurso = new GetCursoByIdQuery.GetCursoByIdQueryHandler(educationDbContextFake, mapper);
            }

            [Test]
            public async Task GetCursoByIdQueryHandler_InputCursoId_ReturnsNotNull()
            {
                GetCursoByIdQuery.GetCursoByIdQueryRequest request = new()
                {
                    Id = cursoIdTest
                };
                var resultado = await handlerByIdCurso.Handle(request, new System.Threading.CancellationToken());

                Assert.IsNotNull(resultado);
            }
        }
    }
}
