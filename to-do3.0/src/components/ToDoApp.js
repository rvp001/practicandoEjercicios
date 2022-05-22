import { nanoid } from "nanoid"

class ToDoApp {
    constructor(){
        this.allToDos = []
        this.inputTask = document.querySelector(".inputTask")
        this.inputTask.onkeyup = (e) => this.handleSubmitInput(e)
        this.divError = document.querySelector(".div-error")
        this.toDoList = document.querySelector(".toDoList")

    }
    
    handleSubmitInput(e) {
        if(e.key!== "Enter") return

        if (this.isEmptyInput()) return
        
        this.newTask(this.inputTask.value)

        this.allToDos= [...this.allToDos, this.newToDo]

        this.printToDos(this.allToDos)

        this.iconCheck = document.querySelector(".iconCheck")
        this.iconDelete = document.querySelector(".iconDelete")





        this.inputTask.value=""
    }

    printToDos(array=this.allToDos){
        this.toDoList.innerHTML=""
        array.forEach(ToDo=>{
            this.createToDo(ToDo)
        })

    }

    newTask(mytask){
        this.newToDo = {
            id: nanoid(),
            task: mytask,
            isCompleted: false
        }       
    }

    isEmptyInput(){
        if (this.inputTask.value.trim()=== ""){
            this.inputTask.classList.add("is-invalid")
            this.divError.classList.remove("d-none")
            return true
        }else {
            this.inputTask.classList.remove("is-invalid")
            this.divError.classList.add("d-none")
            return false
        }
    }

    createToDo(ToDo){
        const newLi = document.createElement("li")

        let iconCircle = ToDo.isCompleted ? "bi-check-circle" : "bi-circle"

        newLi.className="toDo px-3 py-2 bg-white rounded d-flex shadow border"
        newLi.innerHTML = `<i class="iconCheck icon bi ${iconCircle} text-success me-2"></i>
        ${ToDo.task}
        <i class="iconDelete icon ms-auto bi bi-x-lg"></i>`
        this.toDoList.append(newLi)

        let iconCheck= document.querySelector(".iconCheck")
        let iconDelete= document.querySelector(".iconDelete")
        console.dir(iconCheck)

        iconDelete.onclick = () => this.changeCheck(ToDo.id)
     
    }

    changeCheck(Id){
        console.log(Id)
        console.log(this.newToDo)
        this.allToDos= this.allToDos.filter(toDo => Id !== toDo.id) 
        this.printToDos()
       

    }

}


export default ToDoApp