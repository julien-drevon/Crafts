﻿using ElegantCode.Fundamental.Core.DriverAdapter;
using ElegantCode.Fundamental.Core.Errors;
using ElegantCode.Fundamental.Core.UsesCases;
using ElegantCode.Fundamental.Core.Utils;
using Rpg.Core.Domain;
using Rpg.Core.Dto;
using Rpg.Core.UseCases.Query;

namespace Rpg.Core.Dto
{
    public class AddItemsDriverRequest : IValidateRequest<AddItemsWorldUseCaseQuery>
    {
        public AddItemsDriverRequest(Guid correlationToken, Guid id, IEnumerable<ISprite> itemsToAdd = null)
        {
            Id = id;
            Items = itemsToAdd == null 
                    ? new HashSet<ISprite>(itemsToAdd) 
                    : itemsToAdd;
        }

        public Guid CorrelationToken { get; }

        public Guid Id { get; internal set; }

        public IEnumerable<ISprite> Items { get; set; }

        public (AddItemsWorldUseCaseQuery UseCaseQuery, Error Error) ValidateRequest()
        {
            return this.ValidationWorkflow(valueIfIsGood: new AddItemsWorldUseCaseQuery(CorrelationToken, Id, Items));
        }
    }


}