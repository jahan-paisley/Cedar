Service: Define service classes which mostly do operations involving one or more repositories.
         Beware of Anemic Domain Model anti-pattern, do not make methods fat, knowledge about the domain must be in Domain project.
		 ServiceBase defines the CRUD operations, For any other method you must develop your own interface and implmentation.
