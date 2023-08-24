// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
    const filterForm = document.getElementById('filterForm');
    const appointmentsDiv = document.getElementById('appointments');

    let navbar = document.getElementById("navbar");
    let navButton = document.getElementById("navToggleBtn");
    let toggle = false;

  
    navButton.addEventListener('click', () => {
        if (toggle === false) {
            navbar.classList.remove("hide");
            toggle = true;
        } else {
            navbar.classList.add("hide");
            toggle = false;
        }
        
    })

    filterForm.addEventListener('submit', async (event) => {
        event.preventDefault();

        const PhysicianId = document.getElementById('PhysicianID').value;
        const response = await fetch(`/Appointment/ViewPhysicianAppointments/?PhysicianID=${PhysicianID}`);
        const appointments = await response.json();

        // Clear previous appointments and render new ones
        appointmentsDiv.innerHTML = `
            <h1>Appointments for Physician ${PhysicianID}</h1>
            <ul>
                ${appointments.map(Appointment => `<li>${Appointment}</li>`).join('')}
            </ul>
        `;
    });
});

