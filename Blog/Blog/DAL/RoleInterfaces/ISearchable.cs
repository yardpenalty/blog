//more here : http://msdn.microsoft.com/en-us/library/bb546158.aspx

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace BlogSite.DAL.RoleInterfaces
//{

//    using BlogSite.DAL.RoleInterfaces.LinqProvider;
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Linq.Expressions;

//    namespace LinqProvider
//    {
//        public class QueryableSearchData<TData> : IOrderedQueryable<TData>
//        {
//            #region Constructors
//            /// <summary> 
//            /// This constructor is called by the client to create the data source. 
//            /// </summary> 
//            public QueryableSearchData()
//            {
//                Provider = new SearchQueryProvider();
//                Expression = Expression.Constant(this);
//            }

//            /// <summary> 
//            /// This constructor is called by Provider.CreateQuery(). 
//            /// </summary> 
//            /// <param name="expression"></param>
//            public QueryableSearchData(SearchQueryProvider provider, Expression expression)
//            {
//                if (provider == null)
//                {
//                    throw new ArgumentNullException("provider");
//                }

//                if (expression == null)
//                {
//                    throw new ArgumentNullException("expression");
//                }

//                if (!typeof(IQueryable<TData>).IsAssignableFrom(expression.Type))
//                {
//                    throw new ArgumentOutOfRangeException("expression");
//                }

//                Provider = provider;
//                Expression = expression;
//            }
//            #endregion

//            #region Properties

//            public IQueryProvider Provider { get; private set; }
//            public Expression Expression { get; private set; }

//            public Type ElementType
//            {
//                get { return typeof(TData); }
//            }

//            #endregion

//            #region Enumerators
//            public IEnumerator<TData> GetEnumerator()
//            {
//                return (Provider.Execute<IEnumerable<TData>>(Expression)).GetEnumerator();
//            }

//            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
//            {
//                return (Provider.Execute<System.Collections.IEnumerable>(Expression)).GetEnumerator();
//            }
//            #endregion
//        }


//    }

//    public class SearchQueryProvider : IQueryProvider
//    {
//        public IQueryable CreateQuery(Expression expression)
//        {
//            Type elementType = TypeSystem.GetElementType(expression.Type);
//            try
//            {
//                return (IQueryable)Activator.CreateInstance(typeof(QueryableSearchData<>).MakeGenericType(elementType), new object[] { this, expression });
//            }
//            catch (System.Reflection.TargetInvocationException tie)
//            {
//                throw tie.InnerException;
//            }
//        }

//        // Queryable's collection-returning standard query operators call this method. 
//        public IQueryable<TResult> CreateQuery<TResult>(Expression expression)
//        {
//            return new QueryableSearchData<TResult>(this, expression);
//        }

//        public object Execute(Expression expression)
//        {
//            return SearchQueryContext.Execute(expression, false);
//        }

//        // Queryable's "single value" standard query operators call this method.
//        // It is also called from QueryableTerraServerData.GetEnumerator(). 
//        public TResult Execute<TResult>(Expression expression)
//        {
//            bool IsEnumerable = (typeof(TResult).Name == "IEnumerable`1");

//            return (TResult)SearchQueryContext.Execute(expression, IsEnumerable);
//        }

//        class SearchQueryContext
//        {
//            // Executes the expression tree that is passed to it. 
//            internal static object Execute(Expression expression, bool IsEnumerable)
//            {
//                // The expression must represent a query over the data source. 
//                if (!IsQueryOverDataSource(expression))
//                    throw new InvalidProgramException("No query over the data source was specified.");

//                // Find the call to Where() and get the lambda expression predicate.
//                InnermostWhereFinder whereFinder = new InnermostWhereFinder();
//                MethodCallExpression whereExpression = whereFinder.GetInnermostWhere(expression);
//                LambdaExpression lambdaExpression = (LambdaExpression)((UnaryExpression)(whereExpression.Arguments[1])).Operand;

//                // Send the lambda expression through the partial evaluator.
//                lambdaExpression = (LambdaExpression)Evaluator.PartialEval(lambdaExpression);

//                // Get the place name(s) to query the Web service with.
//                LocationFinder lf = new LocationFinder(lambdaExpression.Body);
//                List<string> locations = lf.Locations;
//                if (locations.Count == 0)
//                    throw new InvalidQueryException("You must specify at least one place name in your query.");

//                // Call the Web service and get the results.
//                Place[] places = WebServiceHelper.GetPlacesFromTerraServer(locations);

//                // Copy the IEnumerable places to an IQueryable.
//                IQueryable<Place> queryablePlaces = places.AsQueryable<Place>();

//                // Copy the expression tree that was passed in, changing only the first 
//                // argument of the innermost MethodCallExpression.
//                ExpressionTreeModifier treeCopier = new ExpressionTreeModifier(queryablePlaces);
//                Expression newExpressionTree = treeCopier.Visit(expression);

//                // This step creates an IQueryable that executes by replacing Queryable methods with Enumerable methods. 
//                if (IsEnumerable)
//                    return queryablePlaces.Provider.CreateQuery(newExpressionTree);
//                else
//                    return queryablePlaces.Provider.Execute(newExpressionTree);
//            }

//            private static bool IsQueryOverDataSource(Expression expression)
//            {
//                // If expression represents an unqueried IQueryable data source instance, 
//                // expression is of type ConstantExpression, not MethodCallExpression. 
//                return (expression is MethodCallExpression);
//            }
//        }

//    }
//}