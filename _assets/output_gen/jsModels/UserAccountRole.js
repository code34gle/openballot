
//---------------------------------------------------------------------------

export default class UserAccountRole {
  constructor(options) {

    this.Id = null;
    this.UserAccountId = null;
    this.RoleId = null;
    this.UserAccount = null;
    this.Role = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.UserAccountId = options.UserAccountId || this.UserAccountId;
    this.RoleId = options.RoleId || this.RoleId;
    this.UserAccount = options.UserAccount || this.UserAccount;
    this.Role = options.Role || this.Role;

  }  
  //---------------------------------------------------------------------------  
}