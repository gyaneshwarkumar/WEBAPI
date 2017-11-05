
import { Component, OnInit, NgModule, Injectable } from '@angular/core';
import { NgForm, ReactiveFormsModule, FormsModule, FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Student } from '../../_models/index';
import { StudentService } from '../../_services/index';
//Third Party js
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, DataListModule, DropdownModule, CalendarModule } from 'primeng/primeng';
//import { Course } from '../../_models/index';





class StudentInfo implements Student {
    constructor(
        public id?,
        public academics_Mentor?,
        public academics_Mentor_Designation?,
        public address?,
        public addressLine1?,
        public addressLine2?,
        public addressLine3?,
        public app_Status?,
        public batch?,
        public bloodGroup?,
        public caste?,
        public category?,
        public centerId?,
        public city?,
        public country?,
        public course?,
        public create_date?,
        public createdDate?,
        public dOB?,
        public dOJ?,
        public del_Status?,
        public education?,
        public email?,
        public encryptedMobileNo?,
        public entrance_Exam?,
        public fCRollNo?,
        public father_Address?,
        public firstName?,
        public gaps_In_Education?,
        public gender?,
        public graduation?,
        public hSC_Marks?,
        public iP_Address?,
        public isAknowledgemail?,
        public lastName?,
        public localGuardian?,
        public mAT_CAT?,
        public mentorid?,
        public middleName?,
        public mobileNo?,
        public pIBMEmailId?,
        public pRNNo?,
        public phoneNo?,
        public photo?,
        public physicallyHandicapped?,
        public pincode?,
        public relative?,
        public religion?,
        public rollNo?,
        public sSC_Marks?,
        public section?,
        public semester?,
        public specializationMajor?,
        public specialization_Minor?,
        public state?,
        public user_Id?,
        public valid_Code?,
        public whatsappMobileNo?
    ) { }
}

@Component({
    selector: 'student',
    templateUrl: './student.component.html'
})


export class AddStudentComponent implements OnInit {
    public forecasts: Student[];
    public editContactId: any;
    student: Student = new StudentInfo();
    students: Student[];
    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    newBatch: boolean;
    academic_Year: string;
    studentCourse: boolean;


    constructor(private toastrService: ToastrService, private studentService: StudentService) {

    }

    ngOnInit() {
        //this.editContactId = 0;
        this.loadData();
        this.studentCourse = false;
    }

    loadData() {
        this.studentService.getStudents()
            .subscribe(data => this.students = data,
            error => console.log(error));
    }
  
    onRowSelect(event) {
    }

    cancel() {
        this.displayDialog = false;
    }

    save(student: NgForm) {
        this.studentService.saveStudent(this.student)
            .subscribe(response => {
                this.student.id > 0 ? this.toastrService.success('Data updated Successfully') :
                    this.toastrService.success('Data inserted Successfully');
                this.loadData();
            });
        this.displayDialog = false;

    }

    update(student) {
        this.studentService.updateStudent(this.student)
            .subscribe(response => {
                this.student.id > 0 ? this.toastrService.success('Data updated Successfully') :
                    this.toastrService.success('Data inserted Successfully');
                this.loadData();
            });
        this.displayDialog = false;
        this.loadData();
    }

    //showDialogToDelete(student: Student) {
    //    this.student.Acedemic_Year = batch.Acedemic_Year;

    //    this.student.id = batch.id;
    //    this.displayDeleteDialog = true;
    //}

    //okDelete(isDeleteConfirm: boolean) {
    //    if (isDeleteConfirm) {
    //        this.studentService.deleteStudent(this.student.id)
    //            .subscribe(response => {
    //                this.editContactId = 0;
    //                this.loadData();
    //            });
    //        this.toastrService.error('Data Deleted Successfully');
    //    }
    //    this.displayDeleteDialog = false;
    //    this.loadData();
    //}
}

