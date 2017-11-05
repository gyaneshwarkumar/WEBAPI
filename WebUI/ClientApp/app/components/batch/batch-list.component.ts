import { Component, OnInit } from '@angular/core';
import { Batch } from '../../_models/index';
import { BatchService } from '../../_services/index';
//Third Party js
import { ToastrService } from 'toastr-ng2';
import { InputTextModule, DataTableModule, ButtonModule, DialogModule, DataListModule } from 'primeng/primeng';
import { UserService } from '../../user/user.service';


class BatchInfo implements Batch {
    constructor(public id?, public academic_Year?
        //public batch_Name?, public course_Id?, public description?
    ) { }
}

@Component({
    selector: 'batch',
    templateUrl: './batch-list.component.html'
})
export class BatchComponent implements OnInit {
    public forecasts: Batch[];
    public editContactId: any;
    batch: Batch = new BatchInfo();
    batchs: Batch[];
    private rowData: any[];
    displayDialog: boolean;
    displayDeleteDialog: boolean;
    newBatch: boolean;
    academic_Year: string;
    templateUrl1: string;



    constructor(private batchService: BatchService, private toastrService: ToastrService,
        private authService: UserService) {

    }

    ngOnInit() {
        this.loadData();

    }
 
    loadData() {
        this.templateUrl1 = "./batch";
        this.authService.checkathentication(this.templateUrl1)
        this.batchService.getBatchs()
            .subscribe(batchs => this.rowData = batchs,
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
        this.batch.academic_Year = batch.academic_Year;
        //this.batch.batch_Name = batch.batch_Name;
        //this.batch.course_Id = batch.course_Id;
        //this.batch.description = batch.description;

        this.displayDialog = true;


    }
    onRowSelect(event) {
    }

    cancel() {
        this.displayDialog = false;
    }

    save(batch) {
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
        this.batch.academic_Year = batch.academic_Year;
        //this.batch.batch_Name = batch.batch_Name;
        //this.batch.course_Id = batch.course_Id;
        //this.batch.description = batch.description;
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


