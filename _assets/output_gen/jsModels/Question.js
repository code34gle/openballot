
//---------------------------------------------------------------------------

export default class Question {
  constructor(options) {

    this.Id = null;
    this.Text = null;
    this.Yes = null;
    this.No = null;

    if(options) {
      this.init(options);
    }
  }

  //---------------------------------------------------------------------------
  init(options) {

    this.Id = options.Id || this.Id;
    this.Text = options.Text || this.Text;
    this.Yes = options.Yes || this.Yes;
    this.No = options.No || this.No;

  }  
  //---------------------------------------------------------------------------  
}