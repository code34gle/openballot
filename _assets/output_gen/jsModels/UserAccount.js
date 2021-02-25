
//---------------------------------------------------------------------------

export default class UserAccount {
  constructor(options) {

    this.Id = null;
    this.Username = null;
    this.Password = null;
    this.EmailAddress = null;
    this.LoginCount = null;
    this.LastLogin = null;
    this.DateCreated = null;
    this.DateUpdated = null;
    this.UpdatedBy = null;
    this.UserAccountRoles = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.Username = options.Username || this.Username;
    this.Password = options.Password || this.Password;
    this.EmailAddress = options.EmailAddress || this.EmailAddress;
    this.LoginCount = options.LoginCount || this.LoginCount;
    this.LastLogin = options.LastLogin || this.LastLogin;
    this.DateCreated = options.DateCreated || this.DateCreated;
    this.DateUpdated = options.DateUpdated || this.DateUpdated;
    this.UpdatedBy = options.UpdatedBy || this.UpdatedBy;
    this.UserAccountRoles = options.UserAccountRoles || this.UserAccountRoles;

  }  
  //---------------------------------------------------------------------------  
}