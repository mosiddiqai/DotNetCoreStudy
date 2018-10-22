using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples
{
	/*
	 * Problem statement : 
	 *		1) Managing multiple responsibility
	 *		Here User class is responsibile for providing basic functionality for CRUD operation of USer
	 *		However, it is also managing the responsibility to create UserDAL class object
	 *		
	 *		2) Deciding which type of DAL to user
	 *		Suppose in futurer we also want to extend the functionality to also include different database type:
	 *			2.1) Sql server
	 *			2.2) Excel 
	 *			2.3) MsSql
	 *			2.4) Oracle 
	 *			etc
	 *			
	 *			
	 *	Solution
	 *		Responsibility of creating the DAL class should be inverted to client calling it (or somewhere else)
	 */


    public class User //Service Layer or Business Layer
    {
        public IUserDal dal;

        public User(IUserDal dal)
        {
            this.dal = dal;
        }

        public bool IsValid()
        {
            return true;
        }

        public void Add()
        {
            if (IsValid())
            {
                //adding to user
                dal.Add(this);
            }
        }
    }

    public interface IUserDal
    {
        void Add(User user);
    }
    //public class UserDal
    public class MsSqlDal : IUserDal
    {
        public void Add(User user)
        {
            // To do : inserting into database
            Console.WriteLine("User added into MsSql database system");
        }
    }

    public class SqlServerDal : IUserDal
    {
        public void Add(User user)
        {
            // To do : inserting into database
            Console.WriteLine("User added into Sql Server database");
        }
    }
}
