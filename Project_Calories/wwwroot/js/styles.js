const styles = {
    container: {
        fontFamily: 'Arial, sans-serif',
        maxWidth: '800px',
        margin: 'auto',
        padding: '20px',
    },
    heading: {
        color: '#333',
        textAlign: 'center',
    },
    addButton: {
        margin: '15px 0',
    },
    table: {
        width: '100%',
        borderCollapse: 'collapse',
        marginTop: '20px',
    },
    th: {
        backgroundColor: '#f2f2f2',
        padding: '10px',
        textAlign: 'left',
    },
    td: {
        padding: '10px',
        borderBottom: '1px solid #ddd',
    },
    actions: {
        display: 'flex',
        justifyContent: 'space-between',
    },
    editButton: {
        background: '#4CAF50',
    },
    deleteButton: {
        background: '#f44336',
    },
};

window.onload = function () {
    const container = document.getElementById('foodContainer');
    Object.assign(container.style, styles.container);
};
