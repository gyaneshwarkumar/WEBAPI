import { Component, OnInit } from '@angular/core';
import { Login } from '../../_models/index';
import { LoginService } from '../../_services/index';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
//Third Party js
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';
import { UserService } from '../../user/user.service';

class LoginInfo implements Login {
    constructor(public email?, public password?) { }
}

@Component({
    selector: 'login',
    templateUrl: './login.component.html',

})
export class LoginComponent implements OnInit {
    public forecasts: Login[];
    public editContactId: any;
    signup: Login = new LoginInfo();
    signups: Login[];
    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    newCourse: boolean;
    errorMessage: string;
    userName: string;
    password: string;

    public editCourseId: any;
    public fullname: string;
    public newTrustFormVisible: boolean;
    public showElement: boolean;

    constructor(private loginService: LoginService, private toastrService: ToastrService, private authService: UserService,
        private router: Router) {

    }

    showDialogToAdd() {
        this.newCourse = true;
        this.editCourseId = 0;
        this.signup = new LoginInfo();
        this.displayDialog = true;

    }

    ngOnInit() {
      //  this.showElement = false;
    }

    onRowSelect(event) {
    }

    cancel() {
        this.displayDialog = false;
    }

    save(signup: NgForm) {
        var result = this.loginService.login(this.signup).subscribe(
            response => {
                if (this.authService.redirectUrl) {
                    this.router.navigateByUrl(this.authService.redirectUrl);
                } else {
                    this.showElement = true;
                    this.router.navigate(['/home']);

                }
            },
            error => {
                var results = error['_body'];
                this.errorMessage = error.statusText + ' ' +

                    error.text();
            });
        this.displayDialog = false;
        // this.loadData();
    }


}


