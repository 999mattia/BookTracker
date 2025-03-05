import { NgModule, LOCALE_ID } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ObMasterLayoutModule, ObButtonModule, provideObliqueConfiguration, ObHttpApiInterceptor, ObExternalLinkModule } from '@oblique/oblique';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { registerLocaleData } from '@angular/common';
import localeDECH from '@angular/common/locales/de-CH';
import localeFRCH from '@angular/common/locales/fr-CH';
import localeITCH from '@angular/common/locales/it-CH';
import { TranslateModule } from '@ngx-translate/core';
import { provideHttpClient, HTTP_INTERCEPTORS, withInterceptorsFromDi } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

registerLocaleData(localeDECH);
registerLocaleData(localeFRCH);
registerLocaleData(localeITCH);

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    AppRoutingModule,
    ObMasterLayoutModule,
    BrowserAnimationsModule,
    ObButtonModule,
    TranslateModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    ObExternalLinkModule
  ],
  providers: [
    {provide: LOCALE_ID, useValue: 'de-CH'},
    provideObliqueConfiguration({accessibilityStatement: {applicationName: 'BookTracker.Client', applicationOperator: 'Replace me with the name and address of the federal office that exploit this application, HTML is permitted', contact: {/* at least 1 email or phone number has to be provided */ emails: [''], phones: ['']}}}),
    {provide: HTTP_INTERCEPTORS, useClass: ObHttpApiInterceptor, multi: true},
    provideHttpClient(withInterceptorsFromDi())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
