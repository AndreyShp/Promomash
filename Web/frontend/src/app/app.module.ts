import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';

import { RegistrationWizardComponent } from './registration-wizard/registration-wizard.component';
import { RegistrationWizardStep1Component } from './registration-wizard/step1/registration-wizard-step1.component';
import { RegistrationWizardStep2Component } from './registration-wizard/step2/registration-wizard-step2.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationWizardComponent,
    RegistrationWizardStep1Component,
    RegistrationWizardStep2Component
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule, 
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatCheckboxModule,
    MatFormFieldModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
