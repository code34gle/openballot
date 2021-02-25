
//---------------------------------------------------------------------------

export default class Role {
  constructor(options) {

    this.Id = null;
    this.RoleName = null;
    this.UserAccountRoles = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.RoleName = options.RoleName || this.RoleName;
    this.UserAccountRoles = options.UserAccountRoles || this.UserAccountRoles;

  }  
  //---------------------------------------------------------------------------  
}