import { Component, Output, EventEmitter } from '@angular/core';
import { UserWizardState, UserData } from './registration-wizard-data.module';

@Component({
  selector: 'registration-wizard',
  templateUrl: './registration-wizard.component.html',
  styleUrls: ['./registration-wizard.component.css']
})

export class RegistrationWizardComponent {
  public state: UserWizardState;

  constructor() {
    this.state = new UserWizardState();
    this.state.step = 1;
    this.state.user = new UserData();
  }

  setState(state: UserWizardState) {
    this.state = state;
  }
}
