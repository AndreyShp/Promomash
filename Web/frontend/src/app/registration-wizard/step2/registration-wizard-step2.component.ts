import { Component, Input, Inject } from '@angular/core';
import { FormControl, Validators, NgForm } from '@angular/forms';
import { MatSelectChange } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { UserWizardState, UserData } from '../registration-wizard-data.module';

export interface Region {
  id: number,
  name: string
}

enum RegionType {
  Country = 1,
  Province = 2
}

type CallbackFunctionType = (item: Region[]) => void;

@Component({
  selector: 'registration-wizard-step2',
  templateUrl: './registration-wizard-step2.component.html',
  styleUrls: ['./../registration-wizard.component.css']
})

export class RegistrationWizardStep2Component {
  private _http: HttpClient;
  private _selectedCountryId: number;
  private _state: UserWizardState;
  private _apiUrl: string;

  public countryControl = new FormControl('', [Validators.required]);
  public provinceControl = new FormControl('', [Validators.required]);
  public countries : Region[];
  public provinces : Region[];

  @Input('initialState')
  set initialState(state: UserWizardState) {
    this._state = state;
    debugger; //????
    this.loadRegions(RegionType.Country, 0, result => {
      this.countries = result;
    });
  }

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    this._http = http;
    this._apiUrl = apiUrl;
  }
 
  changeCountry(event: MatSelectChange) {
    debugger; //????
    if (this._selectedCountryId == event.value.id) {
      return;
    }
    this._selectedCountryId = event.value.id;
    
    this.provinces = null;
    this.loadRegions(RegionType.Province, this._selectedCountryId, result => {
      this.provinces = result;
    });
  }

  changeProvince(event: MatSelectChange) {
    this._state.user.regionId = event.value.id;
  }

  private loadRegions(type: RegionType, parentId: number, successCallback: CallbackFunctionType) {
    let url = this._apiUrl + `regions?types=${type}`;
    if (parentId > 0) {
      url += 'parentsIds=' + parentId;
    }
    this._http.get<Region[]>(url).subscribe(successCallback, error => console.error(error));
  }

  onSubmit(f: NgForm) {
    //TODO: вернуть валидацию
    /*if (!f.valid) {
      return;
    }*/
    alert (this._state.user.login + ' ' + this._state.user.password + ' ' + this._state.user.regionId); ///????
  }
}