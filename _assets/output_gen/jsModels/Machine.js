
//---------------------------------------------------------------------------

export default class Machine {
  constructor(options) {

    this.Id = null;
    this.MAC_Address = null;
    this.IP_Address = null;
    this.District = null;
    this.Precinct = null;
    this.Status = null;
    this.IsActive = null;
    this.DateUpdated = null;
    this.UpdatedBy = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.MAC_Address = options.MAC_Address || this.MAC_Address;
    this.IP_Address = options.IP_Address || this.IP_Address;
    this.District = options.District || this.District;
    this.Precinct = options.Precinct || this.Precinct;
    this.Status = options.Status || this.Status;
    this.IsActive = options.IsActive || this.IsActive;
    this.DateUpdated = options.DateUpdated || this.DateUpdated;
    this.UpdatedBy = options.UpdatedBy || this.UpdatedBy;

  }  
  //---------------------------------------------------------------------------  
}