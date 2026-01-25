using SchoolDigital.Core.Entities;
using SchoolDigital.Core.Repositories;
using SchoolDigital.Core.Service;

namespace SchoolDigital.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _irepositoryManager;

        // בנאי אחד בלבד שמקבל את המנהל של ה-Repositories
        public UserService(IRepositoryManager irepositoryManager)
        {
            _irepositoryManager = irepositoryManager;
        }

        public IEnumerable<User> GetUsers() => _irepositoryManager.Users.GetAll();

        public User? GetById(int id) => _irepositoryManager.Users.GetById(id);

        public User Add(User user)
        {
            _irepositoryManager.Users.Add(user);
            _irepositoryManager.SaveChanges();
            return user;
        }

        public User? Update(int id, User user)
        {
            var exists = _irepositoryManager.Users.GetById(id);
            if (exists == null) return null;

            _irepositoryManager.Users.Update(user);
            _irepositoryManager.SaveChanges();
            return user;
        }

        // מימוש מחיקה לוגית (שינוי סטטוס) כפי שמופיע באפיון וב-UserRepository המקורי
        public void Delete(User user)
        {
            // אם תרצה מחיקה לוגית (Soft Delete):
            user.Status = EStatus.inactive;
            _irepositoryManager.Users.Update(user);

            // מחיקה פיזית מהמסד:
            //_irepositoryManager.Users.Delete(user);
            //_irepositoryManager.SaveChanges();
        }

        // חיפוש משתמש לפי שם וסיסמה באמצעות ה-Find הכללי
        public User? SearchUser(string pas, string name)
        {
            return _irepositoryManager.Users.Find(u => u.Password == pas && u.Name == name).FirstOrDefault();
        }
    }
}