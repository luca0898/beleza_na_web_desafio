using BelezanaWeb.Product.Contracts.Repositories;
using BelezanaWeb.Product.Contracts.Services;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Service;
using BelezanaWeb.SystemObjects;
using BelezanaWeb.SystemObjects.Exceptions;
using BelezanaWeb.SystemObjects.Interfaces;
using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Tests.Unit
{
    [TestFixture(Category = "ScheduleUnits")]
    public class ScheduleServicesTests
    {
        IScheduleService _service;
        IScheduleRepository _repository;
        IUnitOfWorkFactory<UnitOfWork> _uow;

        [SetUp]
        public void SetUp()
        {
            _repository = A.Fake<IScheduleRepository>();
            _uow = A.Fake<IUnitOfWorkFactory<UnitOfWork>>();

            _service = new ScheduleService(_repository, _uow);
        }

        [Test]
        public async Task FindAll_ShouldCallRepository()
        {
            int skip = 0;
            int take = 10;
            var cancellationToken = new CancellationTokenSource().Token;

            await _service.FindAllAsync(cancellationToken, skip, take);

            A.CallTo(() => _repository.FindAll(cancellationToken, skip, take))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task GetOne_ShouldCallRepository()
        {
            int id = 0;
            var cancellationToken = new CancellationTokenSource().Token;

            await _service.GetOneAsync(id, cancellationToken);

            A.CallTo(() => _repository.FindOne(id, cancellationToken))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task Create_ShouldCallRepository()
        {
            Schedule entity = A.Fake<Schedule>();
            var cancellationToken = new CancellationTokenSource().Token;

            await _service.CreateAsync(entity, cancellationToken);

            A.CallTo(() => _repository.Create(entity, cancellationToken))
                .MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task Update_ShouldNotUpdate_WhenNoFoundEntityRecord()
        {
            try
            {
                Schedule entity = new Schedule { Id = 1 };
                var cancellationToken = new CancellationTokenSource().Token;
                A.CallTo(() => _repository.FindOne(entity.Id, cancellationToken))
                    .Returns(Task.FromResult<Schedule>(null));

                await _service.UpdateAsync(entity.Id, entity, cancellationToken);

                A.CallTo(() => _repository.Update(entity, cancellationToken))
                    .MustNotHaveHappened();
            }
            catch (BelezanaWebApplicationException ex)
            {
                if (ex.Message.Equals($"Schedule 1 not found"))
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail(ex.Message);
                }
            }
        }

        [Test]
        public async Task Update_ShouldCallUpdateRepository_WhenFoundEntityRecord()
        {
            Schedule entity = new Schedule { Id = 1 };
            var cancellationToken = new CancellationTokenSource().Token;

            A.CallTo(() => _repository.FindOne(entity.Id, cancellationToken)).Returns(entity);
            A.CallTo(() => _repository.Update(entity, cancellationToken)).Returns(entity);

            Schedule entityAfterUpdate = await _service.UpdateAsync(entity.Id, entity, cancellationToken);

            A.CallTo(() => _repository.Update(entity, cancellationToken)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task Delete_ShouldSetEntityAsDeleted_WhenFoundEntityRecord()
        {
            int id = 1;
            Schedule entity = new Schedule { Id = 1 };
            var cancellationToken = new CancellationTokenSource().Token;

            A.CallTo(() => _repository.FindOne(entity.Id, cancellationToken)).Returns(entity);

            await _service.DeleteAsync(id, cancellationToken);

            A.CallTo(() => _repository.SoftDelete(entity, cancellationToken)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task Delete_ShouldNotDeleteEntity_WhenNoFoundEntityRecord()
        {
            try
            {
                int id = 1;
                Schedule entity = new Schedule { Id = 1 };
                var cancellationToken = new CancellationTokenSource().Token;

                A.CallTo(() => _repository.FindOne(entity.Id, cancellationToken))
                    .Returns(Task.FromResult<Schedule>(null));

                await _service.DeleteAsync(id, cancellationToken);

                A.CallTo(() => _repository.SoftDelete(entity, cancellationToken)).MustNotHaveHappened();
            }
            catch (BelezanaWebApplicationException ex)
            {
                if (ex.Message.Equals($"Schedule 1 not found"))
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail(ex.Message);
                }
            }
        }
    }
}
