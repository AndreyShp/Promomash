import { Component, Input, Output, EventEmitter } from '@angular/core';
import { ErrorStateMatcher } from '@angular/material';
import { FormGroup, FormBuilder, FormControl, FormGroupDirective, Validators, AbstractControl, NgForm } from '@angular/forms';
import { UserWizardState, UserData } from '../registration-wizard-data.module';

export class CrossFieldErrorMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const invalidParent = !!(
      control
      && control.parent
      && control.parent.invalid
      && control.parent.dirty
      && control.parent.hasError('notMatch'));
    return (invalidParent);
  }
}

@Component({
  selector: 'registration-wizard-step1',
  templateUrl: './registration-wizard-step1.component.html',
  styleUrls: ['./../registration-wizard.component.css']
})

export class RegistrationWizardStep1Component {
  private _state: UserWizardState;

  public form: FormGroup;
  public loginControl : FormControl;
  public passwordControl : FormControl;
  public confirmPasswordControl : FormControl;
  public agreeControl : FormControl;
  public errorMatcher = new CrossFieldErrorMatcher();

  @Input('initialState')
  set initialState(state: UserWizardState) {
    this._state = state;
  }

  @Output() setState: EventEmitter<UserWizardState> = new EventEmitter();

  private confirmPasswordValidator(frm: FormGroup) : { [key: string]: boolean } | null {
    var psw1 = frm.get('password');
    var psw2 = frm.get('confirmPassword');
    if (psw1 == null || psw2 == null) {
      return null;
    }

    const condition = psw2.value == null || psw2.value == '' || psw1.value !== psw2.value;
    var result = condition ? { 'notMatch': true} : null;
    return result;
  }

  private passwordValidator(control: AbstractControl): { [key: string]: boolean } | null {
    var val = control.value || '';
    if (!val || !val.match(/\d/) || !val.match(/[A-ZА-Я]/)) {
        return { 'password': true };
    }
    return null;
  }

  constructor(private fb: FormBuilder) {
    this.loginControl = new FormControl('', [
      Validators.required,
      Validators.email
    ]);
    this.passwordControl = new FormControl('', [
      Validators.required,
      this.passwordValidator
    ]);
    this.confirmPasswordControl = new FormControl('', [
      Validators.required
    ]);
    this.agreeControl = new FormControl('', [
      Validators.requiredTrue
    ]);

    this.form = this.fb.group({
      'login': this.loginControl,
      'password': this.passwordControl,
      'confirmPassword': this.confirmPasswordControl,
      'agree': this.agreeControl
    }, { validator: this.confirmPasswordValidator });
  }
 
  onSubmit(f: NgForm) {
    if (!f.valid) {
      return;
    }
    this._state.step = 2;
    this._state.user.login = f.value.login;
    this._state.user.password = f.value.password;

    this.setState.emit(this._state);
  }
}
