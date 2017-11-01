import { Component, OnInit, NgModule, Injectable} from '@angular/core';
import {
    NgForm,
    ReactiveFormsModule,
    FormsModule,
    FormGroup,
    FormControl,
    Validators,
    FormBuilder
} from '@angular/forms';
import { Batch } from '../../_models/index';
import { BatchService, CourseService } from '../../_services/index';
//Third Party js
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, DataListModule, DropdownModule, CalendarModule } from 'primeng/primeng';
import { Course } from '../../_models/index';



class BatchInfo implements Batch {
    constructor(public id?, public acedemic_Year?, public batch_Name?, public course_Id?, public description?,
        public EndDate?, public StartDate?, public App_Status?, public Created_Date?, public Del_Status?,
        public subCourse_Name?, public course_duration?, public pattern?, public batch_incharge?) { }
}

class CourseInfo implements Course {
    constructor(public id?, public course_Name?, public description?) { }
}


@Component({
    selector: 'addbatch',
    templateUrl: './addbatch.component.html'
})


export class AddBatchComponent implements OnInit  {
    public forecasts: Batch[];
    public editContactId: any;
    batch: Batch = new BatchInfo();
    batchs: Batch[];
    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    newBatch: boolean;
    acedemic_Year: string;
    course: Course = new CourseInfo();
    courses: Course[];
    courseList: FormControl;
    StartDate: Date;
    EndDate: Date;


    constructor(private batchService: BatchService, private toastrService: ToastrService, private courseService: CourseService) {

    }

    ngOnInit() {
        //this.editContactId = 0;
        this.loadData();
    }

    loadData() {
       
        this.courseService.getCourses()
            .subscribe(data => this.courses = data,
            error => console.log(error));
          
    }

  
    showDialogToAdd() {
        this.newBatch = true;
        //this.editCourseId = 0;
        this.batch = new BatchInfo();
        this.displayDialog = true;

    }


    showDialogToEdit(batch: Batch) {
        this.newBatch = false;
        this.batch = new BatchInfo();
        this.batch.id = batch.id;
        this.batch.acedemic_Year = batch.acedemic_Year;
        this.batch.batch_Name = batch.batch_Name;
        this.batch.course_Id = batch.course_Id;
        this.batch.description = batch.description;

        this.displayDialog = true;


    }
    onRowSelect(event) {
    }

    cancel() {
        this.displayDialog = false;
    }

    save(batch: NgForm) {
        debugger;
        this.batchService.saveBatch(this.batch)
            .subscribe(response => {
                this.batch.id > 0 ? this.toastrService.success('Data updated Successfully') :
                    this.toastrService.success('Data inserted Successfully');
                this.loadData();
            });
        this.displayDialog = false;

    }

    update(batch) {
        this.batchService.updateBatch(this.batch)
            .subscribe(response => {
                this.batch.id > 0 ? this.toastrService.success('Data updated Successfully') :
                    this.toastrService.success('Data inserted Successfully');
                this.loadData();
            });
        this.displayDialog = false;
        this.loadData();
    }

    showDialogToDelete(batch: Batch) {
        this.batch.acedemic_Year = batch.acedemic_Year;
        this.batch.batch_Name = batch.batch_Name;
        this.batch.course_Id = batch.course_Id;
        this.batch.description = batch.description;
        this.batch.id = batch.id;
        this.displayDeleteDialog = true;
    }

    okDelete(isDeleteConfirm: boolean) {
        if (isDeleteConfirm) {
            this.batchService.deleteBatch(this.batch.id)
                .subscribe(response => {
                    this.editContactId = 0;
                    this.loadData();
                });
            this.toastrService.error('Data Deleted Successfully');
        }
        this.displayDeleteDialog = false;
        this.loadData();
    }
}

