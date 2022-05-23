import { nanoid } from "nanoid"

class ToDoApp {
    constructor(){
        this.allToDos = []
        this.getToDosLocalStorage()
        this.inputTask = document.querySelector(".inputTask")
        this.inputTask.onkeyup = (e) => this.handleSubmitInput(e)
        this.divError = document.querySelector(".div-error")
        this.toDoList = document.querySelector(".toDoList")
        this.filterCounter = document.querySelector(".filterCounter")
        this.counter() 
        this.filterAll = document.querySelector(".filterAll")
        this.filterAll.onclick = () => this.btnAll()
        this.filterActive = document.querySelector(".filterActive")
        this.filterActive.onclick = () => this.btnActive()
        this.filterCompleted = document.querySelector(".filterCompleted")
        this.filterCompleted.onclick = () => this.btnCompleted()
        this.filterClear = document.querySelector(".filterClear")
        this.filterClear.onclick = () => this.btnClear()
         this.printToDos()
    }

    getToDosLocalStorage () {
        this.allToDos = JSON.parse(localStorage.getItem("toDo")) || []
        console.log(this.allToDos)
        console.log(this.allToDos)


    }

    updateToDosLocalStorage () {
        const allToDoString = JSON.stringify(this.allToDos)
        localStorage.setItem("toDo", allToDoString)
    }
    
    btnClear () {
        this.allToDos= []
        this.printToDos()
    }

    btnCompleted () {
        const arrayFiltered = this.allToDos.filter(toDo => toDo.isCompleted !== false) 
        this.printToDos(arrayFiltered)
    }

    btnActive() {
        const arrayFiltered = this.allToDos.filter(toDo => toDo.isCompleted === false) 
        this.printToDos(arrayFiltered)
    }

    btnAll () {
        this.printToDos()
    }

    counter () {
        const arrayFiltered = this.allToDos.filter(toDo => toDo.isCompleted === false)       
        this.filterCounter.innerHTML = `${arrayFiltered.length} tareas pendientes`
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
        this.counter()
        this.updateToDosLocalStorage()
        console.log(this.allToDos)
    }

    newTask(myTask, myId, myIsCompleted){
        this.newToDo = {
            id: myId || nanoid(),
            task: myTask,
            isCompleted: myIsCompleted || false
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

        let iconCircle = ToDo.isCompleted ? "bi-check-circle text-success" : "bi-circle text-info"

        newLi.className="toDo px-3 py-2 bg-white rounded d-flex shadow border"
        newLi.innerHTML = `<i class="iconCheck icon bi ${iconCircle} me-2"></i>
        ${ToDo.task}
        <i class="iconUpdate icon ms-auto bi bi-pencil"></i>
        <i class="iconDelete icon ms-3 bi bi-x-lg"></i>`
        this.toDoList.append(newLi)

        let iconCheck= newLi.querySelector(".iconCheck")
        let iconDelete= newLi.querySelector(".iconDelete")
        let iconUpdate= newLi.querySelector(".iconUpdate")

        iconDelete.onclick = () => this.deleteTask(ToDo.id)
        iconCheck.onclick = () => this.changeCheck(ToDo)
        iconUpdate.onclick = () => this.updateToDo(ToDo)
     
    }

    changeCheck(Do){
        this.allToDos= this.allToDos.map(toDo => {
            if(Do.id === toDo.id) { return {...toDo, isCompleted:!Do.isCompleted}            
            }else {return toDo}
            
        })
       
        this.printToDos()
    }

    updateToDo(Do){
        const modal = document.createElement("div")
        modal.className="modal fade"
        modal.setAttribute("tabindex", "-1")
        modal.setAttribute("data-bs-backdrop", "static")
        modal.setAttribute("data-bs-keyboard", "false")
        // modal.setAttribute("tabindex", "-1")
        modal.innerHTML=`<div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">Modal title</h5>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body">
            <input type="text" value="${Do.task}" class="form-control" id="recipient-name">
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
            <button type="button" class="btn btn-primary">Guardar cambios</button>
          </div>
        </div>
      </div>`
      console.log("hola")

      const myModal = new bootstrap.Modal(modal)
      myModal.show()

    }



    deleteTask(Id){
        this.allToDos= this.allToDos.filter(toDo => Id !== toDo.id)
        this.printToDos()
        }

}


export default ToDoApp