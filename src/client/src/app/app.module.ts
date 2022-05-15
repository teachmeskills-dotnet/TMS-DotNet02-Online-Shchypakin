import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import {AutocompleteLibModule} from 'angular-ng-autocomplete';
import { AngularMaterialModule } from './angular-material.module';
import { PlyrModule } from 'ngx-plyr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { NgSelectModule } from '@ng-select/ng-select';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { LoginComponent } from './login/login.component';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { AlertModule } from 'ngx-bootstrap/alert';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { MembershipCardsComponent } from './membership-cards/membership-cards.component';
import { AssignMembershipComponent } from './assign-membership/assign-membership.component';
import {BsDatepickerModule} from 'ngx-bootstrap/datepicker';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { EditMembershipComponent } from './edit-membership/edit-membership.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HasRoleDirective } from './_directives/has-role.directive';
import { UserEditDataComponent } from './user/user-edit-data/user-edit-data.component';
import { MemberProfileComponent } from './members/member-profile/member-profile.component';
import { MembershipsComponent } from './members/memberships/memberships.component';
import { VideoComponent } from './videopage/video/video.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    MemberListComponent,
    MemberDetailComponent,
    ListsComponent,
    MessagesComponent,
    LoginComponent,
    MembershipCardsComponent,
    AssignMembershipComponent,
    MemberEditComponent,
    TextInputComponent,
    DateInputComponent,
    EditMembershipComponent,
    HasRoleDirective,
    UserEditDataComponent,
    MemberProfileComponent,
    MembershipsComponent,
    VideoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgSelectModule,
    AngularMaterialModule,
    AutocompleteLibModule,
    FormsModule,
    PlyrModule,
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    TabsModule.forRoot(),
    AlertModule.forRoot(),
    CollapseModule.forRoot(),
    BsDatepickerModule.forRoot(),
    NgbModule
  ],

  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
