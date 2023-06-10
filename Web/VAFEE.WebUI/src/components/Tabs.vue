<template>
    <div>
        <div class="tab-buttons">
            <button v-for="(tab, index) in tabs" :key="index" :class="{ active: activeTab === index }"
                @click="setActiveTab(index)">
                {{ tab.label }}
            </button>
        </div>
        <div class="tab-content">
            <slot :name="tabs[activeTab].slot"></slot>
        </div>
    </div>
</template>
  
<script setup lang="ts">
import { ref } from 'vue';

const activeTab = ref(0);
const tabs = [
    { label: 'Tab 1', slot: 'tab1' },
    { label: 'Tab 2', slot: 'tab2' },
    { label: 'Tab 3', slot: 'tab3' },
];

const setActiveTab = (index) => {
    activeTab.value = index;
}

</script>
  
<style>
.tab-buttons {
    display: flex;
    justify-content: space-around;
    margin-bottom: 10px;
}

.tab-buttons button {
    padding: 10px;
    border: none;
    background-color: #ccc;
    cursor: pointer;
}

.tab-buttons button.active {
    background-color: #555;
    color: #fff;
}

.tab-content {
    border: 1px solid #ccc;
    padding: 10px;
}
</style>