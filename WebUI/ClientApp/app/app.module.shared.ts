import { NgModule, forwardRef } from '@angular/core';
import { CommonModule, Location, LocationStrategy, HashLocationStrategy } from '@angular/common';
import { ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { Headers, RequestOptions, BaseRequestOptions } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// third party module to display toast
import { ToastrModule } from 'toastr-ng2';
//PRIMENG - Third party module
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, DataListModule, DropdownModule, CalendarModule } from 'primeng/primeng';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { CommonService } from '../shared/common.service';
import { UserService } from './user/user.service';

import { CourseComponent } from './components/course/course-list.component';
import { CourseService, BatchService, SignupService, LoginService, SubcourseService, StudentService } from './_services/index';
import { BatchComponent } from './components/batch/batch-list.component';
import { AddBatchComponent } from './components/batch/addbatch.component';

import { AddStudentComponent } from './components/student/student.component';

//import { SignupComponent } from './components/registration/signup-list.component';
//import { LoginComponent } from './components/login/login.component';

import { UserModule } from './user/user.module';

import { EqualValidator } from './components/registration/equal-validator.directive';
import { AuthGuard } from '../common/auth.guard';

class AppBaseRequestOptions extends BaseRequestOptions {
    headers: Headers = new Headers();
    constructor() {
        super();
        this.headers.append('Content-Type', 'application/json');
        this.body = '';
    }
}

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        CourseComponent,
        BatchComponent,
        AddBatchComponent,
        AddStudentComponent,
        EqualValidator
        //SignupComponent,
        //LoginComponent
    ],
    imports: [
        CommonModule, InputTextModule, DataTableModule, ButtonModule, DialogModule, DataListModule, DropdownModule, CalendarModule,
        HttpModule,
        UserModule,
        BrowserAnimationsModule,
        ReactiveFormsModule,
        FormsModule,
        ToastrModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'login', pathMatch: 'full' },
            { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'course', component: CourseComponent, canActivate: [AuthGuard] },
            { path: 'student', component: AddStudentComponent, canActivate: [AuthGuard] },
            { path: 'batch', component: BatchComponent, canActivate: [AuthGuard] },
            //{ path: 'addbatch', component: AddBatchComponent },
            //{ path: 'signup', component: SignupComponent },
            //{ path: 'login', component: LoginComponent },

            {
                path: 'addbatch',
                component: AddBatchComponent,
                children: [
                    { path: 'course', component: CourseComponent }
                ]
            },
            { path: '**', redirectTo: 'login' }

            //{ path: '', redirectTo: 'course', pathMatch: 'full' },

            //{ path: '**', redirectTo: 'course' }
        ])
    ]
    ,
    //providers: [
    //    CommonService, CourseService
    //]
    providers: [CommonService, CourseService, BatchService, UserService, SubcourseService, StudentService, AuthGuard,
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        { provide: RequestOptions, useClass: AppBaseRequestOptions }
    ],
})
export class AppModuleShared {
}
