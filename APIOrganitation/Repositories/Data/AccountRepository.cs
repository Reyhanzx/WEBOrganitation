using APIOrganitation.Contexts;
using APIOrganitation.Models;
using Microsoft.EntityFrameworkCore;
using APIOrganitation.ViewModels;
using APIOrganitation.Handlers;

namespace APIOrganitation.Repositories.Data
{
    public class AccountRepository : GeneralRepository<string, Account>
    {
        private readonly MyContext context;

        public AccountRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<int> Register(RegisterVM registerVM)
        {
            int result = 0;
            Member member = new Member
            {
                Nim = registerVM.Nim,
                Name = registerVM.Name,
                Major = registerVM.Major,
                BirthDate = registerVM.BirthDate,
                TitleName = registerVM.TitleName,
                PhoneNumber = registerVM.PhoneNumber,
                Address = registerVM.Address,
                Email = registerVM.Email,
               
            };
            await context.Members.AddAsync(member);
            result = await context.SaveChangesAsync();

            Account account = new Account
            {
                MemberNim = registerVM.Nim,
                Password = Hashing.HashPassword(registerVM.Password)
            };
            await context.Accounts.AddAsync(account);
            result = await context.SaveChangesAsync();

            AccountRole accountRole = new AccountRole
            {
                AccountId = registerVM.Nim,
                RoleId = 5
            };

            await context.AccountRoles.AddAsync(accountRole);
            result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> Login(LoginVM loginVM)
        {
            var result = await context.Members
                .Include(e => e.Account)
                .Select(e => new LoginVM
                {
                    Email = e.Email,
                    Password = e.Account.Password
                }).SingleOrDefaultAsync(a => a.Email == loginVM.Email);

            if (result is null)
            {
                return false;
            }
            return Hashing.ValidatePassword(loginVM.Password, result.Password);
        }

        public async Task<UserdataVM> GetUserdata(string key)
        {
            var userdata = (from e in context.Members
                            join a in context.Accounts
                            on e.Nim equals a.MemberNim
                            join ar in context.AccountRoles
                            on a.MemberNim equals ar.AccountId
                            join r in context.Roles
                            on ar.RoleId equals r.Id
                            where e.Email == key
                            select new UserdataVM
                            {
                                Email = e.Email,
                                FullName = e.Name/*string.Concat(e.FirstName, " ", e.LastName)*/,

                            }).SingleOrDefaultAsync();

            return await userdata;
        }

        public async Task<IEnumerable<string>> GetRolesById(string key)
        {
            var getId = context.Members.FirstOrDefault(e => e.Email == key);
            return await context.AccountRoles.Where(ar => ar.AccountId == getId.Nim).Join(
                context.Roles,
                ar => ar.RoleId,
                r => r.Id,
                (ar, r) => r.Name).ToListAsync();
        }
    }
}
