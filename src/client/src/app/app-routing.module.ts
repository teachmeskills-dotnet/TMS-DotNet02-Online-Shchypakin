import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditMembershipComponent } from './edit-membership/edit-membership.component';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { LoginComponent } from './login/login.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberProfileComponent } from './members/member-profile/member-profile.component';
import { MembershipsComponent } from './members/memberships/memberships.component';
import { MessagesComponent } from './messages/messages.component';
import { RegisterComponent } from './register/register.component';
import { VideoComponent } from './videopage/video/video.component';
import { AdminGuard } from './_guards/admin.guard';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'members', component: MemberListComponent, canActivate: [AdminGuard]},
  {path: 'members/profile', component: MemberProfileComponent, canActivate: [AuthGuard]},
  {path: 'members/profile/editprofile', component: MemberEditComponent, canActivate: [AuthGuard], canDeactivate: [PreventUnsavedChangesGuard]},
  {path: 'memberships/editdata', component: MemberEditComponent, canActivate: [AdminGuard], canDeactivate: [PreventUnsavedChangesGuard]},
  {path: 'members/editmembership', component: EditMembershipComponent, canActivate: [AdminGuard], canDeactivate: [PreventUnsavedChangesGuard]},
  {path: 'memberships', component: MembershipsComponent, canActivate: [AuthGuard]},
  {path: 'lists', component: ListsComponent, canActivate: [AdminGuard]},
  {path: 'messages', component: MessagesComponent},
  {path: 'video', component: VideoComponent, canActivate: [AuthGuard]},
  {path: '**', component: HomeComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
