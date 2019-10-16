import { Component } from '@angular/core';
import { ErrorStateMatcher } from '@angular/material';
import { FormGroup, FormBuilder, FormControl, FormGroupDirective, Validators, AbstractControl, NgForm } from '@angular/forms';

class CrossFieldErrorMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    return control.dirty && form.hasError('notMatch');
  }
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'webApp';
  
  public form: FormGroup;
  public loginControl : FormControl;
  public passwordControl : FormControl;
  public confirmPasswordControl : FormControl;
  public agreeControl : FormControl;
  public errorMatcher = new CrossFieldErrorMatcher();

  private confirmPasswordValidator(frm: FormGroup) : { [key: string]: boolean } | null {
    var psw1 = frm.get('password');
    var psw2 = frm.get('confirmPassword');
    if (psw1 == null || psw2 == null) {
      return null;
    }

    const condition = psw1.value !== psw2.value;
    return condition ? { 'notMatch': true} : null;
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
}
