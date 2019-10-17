import { Component, Input, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
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
  styleUrls: ['./../registration-wizard.component.css', './registration-wizard-step2.component.css']
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
  public message: string;
  public savedUserId: number | null;

  @Input('initialState')
  set initialState(state: UserWizardState) {
    this._state = state;
    this.loadRegions(RegionType.Country, 0, result => {
      this.countries = result;
    }, () => this.message = 'Sorry, can\'t load countries. Try again');
  }

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    this._http = http;
    this._apiUrl = apiUrl;
  }
 
  changeCountry(event: MatSelectChange) {
    if (this._selectedCountryId == event.value.id) {
      return;
    }
    this._selectedCountryId = event.value.id;
    this.provinceControl.reset();

    this.provinces = null;
    this.loadRegions(RegionType.Province, this._selectedCountryId, result => {
      this.provinces = result;
    }, () => this.message = 'Sorry, can\'t load provinces. Try again');
  }

  changeProvince(event: MatSelectChange) {
    this._state.user.regionId = event.value.id;
  }

  private loadRegions(type: RegionType, parentId: number, successCallback: CallbackFunctionType, errorCallback: Function) {
    let url = this._apiUrl + `regions?types=${type}`;
    if (parentId > 0) {
      url += '&parentsIds=' + parentId;
    }
    this._http.get<Region[]>(url).subscribe(successCallback, error => errorCallback(error));
  }

  onSubmit() {
    if (!this.countryControl.valid || !this.provinceControl.valid) {
      return;
    }

    this.message = null;
    this.savedUserId = null;
    this._http.post<UserData>(this._apiUrl + 'users/add', this._state.user).subscribe((user) => {
      this.savedUserId = user.id;
      this.message = `Successfully saved! Your id is ${this.savedUserId}`;
    }, () => {
      this.message = 'Sorry can\'t save user! Try later or change login';
    });
  }
}