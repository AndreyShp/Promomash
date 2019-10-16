import { Component, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators, AbstractControl, NgForm } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { UserWizardState, UserData } from '../registration-wizard-data.module';

@Component({
  selector: 'registration-wizard-step2',
  templateUrl: './registration-wizard-step2.component.html',
  styleUrls: ['./../registration-wizard.component.css']
})

export class RegistrationWizardStep2Component {
  private _http: HttpClient;
  public selectedCountry: Region;
  public selectedProvince: Region;
  public countries : Region[]
  public provinces : Region[]
  private state: UserWizardState;

  @Input('initialState')
  set initialState(state: UserWizardState) {
    this.state = state;
    /*this._http.get<common.Order>('http://localhost:6000/api/regions?types=1').subscribe(result => {
      this.summary = new OrderSummary();

      for (let product of result.products) {
        this.summary.quantity += product.quantity;
        this.summary.price += product.price;
        this.summary.totalPrice += (product.price * product.quantity);
      }

      this.order = result;
    }, error => console.error(error));*/
  }

  constructor(http: HttpClient/*, @Inject('ORDERS_API_URL') apiUrl: string*/) {
    this._http = http;
    //this._apiUrl = apiUrl;
  }
 
  onSubmit(f: NgForm) {
    //TODO: вернуть валидацию
    /*if (!f.valid) {
      return;
    }*/
    alert (this.state.user.login + ' ' + this.state.user.password); ///????
  }
}

export interface Region {
  id: number,
  name: string
}