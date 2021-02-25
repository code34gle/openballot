
//---------------------------------------------------------------------------

export default class ElectionState {
  constructor(options) {

    this.Id = null;
    this.Mode = null;
    this.ElectionStart = null;
    this.ElectionEnd = null;
    this.DateUpdated = null;
    this.UpdatedBy = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.Mode = options.Mode || this.Mode;
    this.ElectionStart = options.ElectionStart || this.ElectionStart;
    this.ElectionEnd = options.ElectionEnd || this.ElectionEnd;
    this.DateUpdated = options.DateUpdated || this.DateUpdated;
    this.UpdatedBy = options.UpdatedBy || this.UpdatedBy;

  }  
  //---------------------------------------------------------------------------  
}