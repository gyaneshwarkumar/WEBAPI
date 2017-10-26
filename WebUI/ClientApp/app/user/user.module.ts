import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LoginComponent } from '../components/login/login.component';
import { SignupComponent } from '../components/registration/signup-list.component';
import { AuthGuard } from '../../common/auth.guard';
import { SharedModule } from '../../shared/shared.module';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';
import { SignupService, LoginService } from '../_services/index';
import {
    UserService,
    UserProfile
} from './index'

@NgModule({
    imports: [
        InputTextModule, DataTableModule, ButtonModule, DialogModule,
        SharedModule,
        RouterModule.forChild([
            { path: 'signup', component: SignupComponent },
            { path: 'login', component: LoginComponent },
        ])
    ],
    declarations: [
        LoginComponent,
        SignupComponent
    ],
    providers: [
        UserService,
        AuthGuard,
        UserProfile,
        SignupService, LoginService
    ]
})
export class UserModule { }