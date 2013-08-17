Data: Define Context, Repositories and UnitOfWork class which will be instantiated once per request.
      In a service you can call multiple methods from different repositories, 
	   but all of these operations will be enclosed in one transaction using a UnitOfWork instance.
	  Repositories should be defined just for Aggregate Roots (more at http://martinfowler.com/bliki/DDD_Aggregate.html)
	  Migrations folder can be used for Database Versioning (more at http://msdn.microsoft.com/en-us/data/jj591621)
	   at the moment, based on naming conventions we discover the Entities and Complex types, but as we go forward
	   we should revert to code first migration as described in the above article.
	  