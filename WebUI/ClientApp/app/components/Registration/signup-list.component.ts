import { Component, OnInit } from '@angular/core';
import { Signup } from '../../_models/index';
import { SignupService } from '../../_services/index';
import { Router } from '@angular/router';
//Third Party js
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule } from 'primeng/primeng';
import { NG_VALIDATORS, Validator, Validators, AbstractControl, ValidatorFn } from '@angular/forms';

class SignupInfo implements Signup {
    constructor(public id?, public email?, public lockoutEnabled?, public passwordHash?, public userName?, public password?, public confirmPassword?) { }
}

@Component({
    selector: 'signup',
    templateUrl: './signup-list.component.html'
})
export class SignupComponent {
    public forecasts: Signup[];
    public editContactId: any;
    signup: Signup = new SignupInfo();
    signups: Signup[];
    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    newCourse: boolean;

    public editCourseId: any;
    public fullname: string;

    constructor(private signupService: SignupService, private toastrService: ToastrService, private router: Router) {

    }



    showDialogToAdd() {
        this.newCourse = true;
        this.editCourseId = 0;
        this.signup = new SignupInfo();
        this.displayDialog = true;

    }


    onRowSelect(event) {
    }

    cancel() {
        this.displayDialog = false;
    }

    save(signup) {
        this.signupService.saveSignup(this.signup)
            .subscribe(response => {
                this.signup.id > 0 ? this.toastrService.success('SignUp Successfully') :
                    this.toastrService.success('Data inserted Successfully');
            });
        this.displayDialog = false;
        this.router.navigate(['/Login.component']);
    }


}


