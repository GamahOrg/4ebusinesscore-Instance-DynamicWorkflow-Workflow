
namespace _4EPlatForm.Infrastructure.Extention.IQueryable
{

    public static class IQueryableExtentions
    {
        /// <summary>
        ///  function execute soft delete to Queryable objects 
        /// </summary>
        public static void ExecuteBulkSoftDelete<T>(this IQueryable<T> queryable) where T : BaseEntity

        {
            queryable.ExecuteUpdate(a => a.SetProperty(x => x.State, State.Deleted));

        }

        /// <summary>
        ///  function execute soft delete to Collection Of Items
        /// </summary>
        public static void ExecuteBulkSoftDelete<T>(this ICollection<T> collection, IGRepository<T> repository) where T : BaseEntity

        {
            if (collection is not null && collection?.Count > 0)
            {
                foreach (var item in collection)
                {
                    item.State = State.Deleted;
                    repository.UpdateEntity(item);

                }
            }


        }


        public static void ExecuteBulkRequireEdit(this ICollection<RequestTransaction> collection, IGRepository<RequestTransaction> repository)

        {
            if (collection is not null && collection?.Count > 0)
            {
                foreach (var item in collection)
                {
                    item.IsRequireEdit = true;
                    repository.UpdateEntity(item);

                }
            }


        }

        public static void ExecuteBulkAddRequireEdit(this ICollection<RequestTransaction> collection, IGRepository<RequireEditFormStep> repository, Guid requestTransactionFromId)

        {
            if (collection is not null && collection?.Count > 0)
            {
                var requireEditFormSteps = collection.Select(a => new RequireEditFormStep
                {
                    RequestTransactionId = a.Id,
                    RequestTransactionFromId = requestTransactionFromId
                }).ToList();

                repository.AddRange(requireEditFormSteps);
            }



        }

        public static IQueryable<RequestInstance> FilterNamesInstances(this IQueryable<RequestInstance> query, List<string> Names)
        {

            var lowerCaseUserNames = Names.Select(n => n.ToLower()).ToList();

            var filterExpression = PredicateBuilder.False<RequestInstance>();
            foreach (var name in lowerCaseUserNames)
            {
                string tempName = name;
                filterExpression = filterExpression.Or(a => a.Name.ToLower().Contains(tempName));
            }

            return query.Where(filterExpression);
        }
        public static IQueryable<AssginRequestInstance> FilterNamesAssginInstances(this IQueryable<AssginRequestInstance> query, List<string> Names)
        {

            var lowerCaseUserNames = Names.Select(n => n.ToLower()).ToList();

            var filterExpression = PredicateBuilder.False<AssginRequestInstance>();
            foreach (var name in lowerCaseUserNames)
            {
                string tempName = name;
                filterExpression = filterExpression.Or(a => a.RequestInstance.Name.ToLower().Contains(tempName));
            }

            return query.Where(filterExpression);
        }

    }
}
